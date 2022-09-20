using AutoMapper;
using KTApps.Core.EF;
using KTApps.Core.Interface;
using KTApps.Core.Paging;
using KTApps.Core.Utils;
using KTApps.Domain;
using KTApps.Models;
using KTApps.Models.Import;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace KTApps.Core.Services
{
    public abstract class CatalogueService<E> : DomainService<E>, ICatalogueService<E> where E : KTAppDomainCatalogue, new()
    {
        public CatalogueService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override bool Save(E item)
        {
            var existCode = unitOfWork.CatalogueRepository<E>().GetQueryable()
                .AsNoTracking()
                .Where(e =>
                e.Code == item.Code
                && !e.Deleted)
                .FirstOrDefault();

            if (existCode != null && item.Id != existCode.Id)
            {
                throw new Exception("Mã đã tồn tại");
            }

            var exists = unitOfWork.CatalogueRepository<E>().GetQueryable()
                .AsNoTracking()
                .Where(e =>
                e.Id == item.Id
                && !e.Deleted)
                .FirstOrDefault();
            if (exists != null)
            {
                exists = mapper.Map<E>(item);
                unitOfWork.CatalogueRepository<E>().Update(exists);
                unitOfWork.Save();
                return true;
            }
            else
            {
                unitOfWork.CatalogueRepository<E>().Create(item);
                unitOfWork.Save();
                return true;

            }
        }

        public virtual E GetByCode(string code)
        {
            return unitOfWork.CatalogueRepository<E>()
                .GetQueryable()
                .Where(e => e.Code == code && !e.Deleted)
                .FirstOrDefault();
        }

        public virtual KTAppDomainImportResult Import(ImportDataModel importData)
        {
            KTAppDomainImportResult importResult = new KTAppDomainImportResult();
            IList<E> importItems = new List<E>();

            using (var package = new ExcelPackage())
            {
                using (var stream = new MemoryStream(importData.FileContent))
                {
                    package.Load(stream);
                    var ws = package.Workbook.Worksheets.FirstOrDefault(e => e.Name == importData.SheetName);
                    if (ws == null)
                    {
                        throw new Exception("SheetName not exists");
                    }

                    int totalRows = ws.Dimension.Rows;
                    int totalSuccess = 0;
                    int totalFailed = 0;
                    for (int row = importData.StartRowIndex; row <= totalRows; row++)
                    {
                        E item = new E
                        {
                            Id = Guid.NewGuid(),
                        };
                        item.Created = DateTime.Now;
                        item.CreatedBy = importData.CreatedBy;
                        item.Updated = DateTime.Now;
                        item.Active = true;

                        foreach (var map in importData.ImportMappings)
                        {
                            string address = map.MappingWithColumn + row;
                            object value = ws.Cells[address].GetValue<object>();
                            if (map.AutoGenerateIfNull &&
                                !string.IsNullOrEmpty(map.AutoGenerateColumn) &&
                                value == null)
                            {
                                value = ws.Cells[map.AutoGenerateColumn + row].GetValue<object>();
                                if (value != null)
                                {
                                    value = StringUtils.ReplaceSpecialChar(value.ToString());
                                }
                            }

                            if (map.Required && value == null)
                            {
                                ws.Cells[row, importData.LogColumnIndex].Value = string.Format("{0} is Required", map.PropertyName);
                                totalFailed++;
                                break;
                            }

                            var prop = item.GetType().GetProperty(map.PropertyName);
                            if (prop != null)
                            {
                                if (prop.PropertyType == typeof(Guid))
                                {
                                    Guid guidValue = new Guid(value.ToString());
                                    prop.SetValue(item, value: guidValue, index: null);
                                }
                                else
                                    prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType), null);

                            }
                        }
                        importItems.Add(item);
                        totalSuccess++;
                        ws.Cells[row, importData.LogColumnIndex].Value = "Ok.";
                    }

                    foreach (var item in importItems)
                    {
                        var updateItem = unitOfWork.CatalogueRepository<E>()
                             .GetQueryable()
                             .AsNoTracking()
                             .FirstOrDefault(e => e.Code == item.Code && !e.Deleted);
                        if (updateItem != null)
                        {
                            item.Id = updateItem.Id;
                            unitOfWork.CatalogueRepository<E>().Update(item);
                        }
                        else
                        {
                            unitOfWork.CatalogueRepository<E>().Create(item);
                        }
                    }

                    unitOfWork.Save();
                    importResult.Success = true;
                    importResult.ResultFile = package.GetAsByteArray();
                    importResult.Data = new
                    {
                        TotalSuccess = totalSuccess,
                        TotalFailed = totalFailed,
                        TotalRows = totalRows
                    };
                }
            }


            return importResult;
        }
    }
}
