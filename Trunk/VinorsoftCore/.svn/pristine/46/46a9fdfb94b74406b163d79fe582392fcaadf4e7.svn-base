using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Quản lý chức năng")]
    [VinorsoftAuthorize2(permission: new string[] { CoreConstants.View })]
    public class PermitObjectController : VinorsoftCatalogueCoreController<PermitObjectDTO, PermitObjects>
    {
        readonly ICoreSlidebarItemService coreSlidebarItemService;
        readonly IPermitObjectService permitObjectService;


        private readonly IList<ControllerDTO> controllerList;
        public PermitObjectController(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<IPermitObjectService>();
            permitObjectService = serviceProvider.GetRequiredService<IPermitObjectService>();
            coreSlidebarItemService = serviceProvider.GetRequiredService<ICoreSlidebarItemService>();
            controllerList = GetControllerFromAsembly();
        }

        public override IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public override object Get(DataSourceLoadOptions loadOptions)
        {
            var query = coreService.Queryable.Select(e => new PermitObjectDTO()
            {
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                Description = e.Description,
                ControllerNames = e.ControllerNames,
                ControllerList = e.ControllerNames.Split(new char[] { ',',';' }),
                Created = e.Created,
                PermitObjectSidebars = e.PermitObjectSidebars.Select(s => new PermitObjectSidebarDTO()
                {
                    SidebarMenuIds = s.SidebarMenuIds
                }).ToList()
            });
            return DataSourceLoader.Load<PermitObjectDTO>(query, loadOptions);
        }


        [HttpGet]
        public object GetSideBars(DataSourceLoadOptions loadOptions)
        {
            loadOptions.DefaultSort = "Name";
            var query = coreSlidebarItemService.Queryable.Where(e => e.ModuleId.HasValue).Select(e => new CoreSlidebarItemDTO()
            {
                Id = e.Id,
                Name = e.Name
            }).OrderBy(e => e.Name)
            .ToList();
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpGet]
        public object GetControllers(DataSourceLoadOptions loadOptions)
        {
            loadOptions.DefaultSort = "Name";
            return DataSourceLoader.Load(controllerList, loadOptions);
        }

        [HttpGet]
        public IActionResult UpdatePermitObject(Guid id)
        {
            PermitObjectDTO result = null;
            try
            {
                result = permitObjectService.Queryable.Where(e => e.Id == id)
                      .Select(e => new PermitObjectDTO()
                      {
                          Id = e.Id,
                          Active = e.Active,
                          Code = e.Code,
                          Name = e.Name,
                          ControllerNames = e.ControllerNames,
                          Created = e.Created,
                          CreatedBy = e.CreatedBy,
                          Updated = DateTime.Now,
                          Deleted = e.Deleted,
                          Description = e.Description,
                          UpdatedBy = LoginContext.Instance.CurrentUser.UserName,
                          PermitObjectSidebars = e.PermitObjectSidebars.Select(s => new PermitObjectSidebarDTO()
                          {
                              Id = s.Id,
                              SidebarMenuIds = s.SidebarMenuIds
                          }).ToList(),
                      }).FirstOrDefault();

                if (result != null)
                {
                    result.ControllerList = !string.IsNullOrEmpty(result.ControllerNames) ? result.ControllerNames.Split(",") : new string[] { };
                    result.SelectedSidebars = new List<Guid>();
                    foreach (var sidebar in result.PermitObjectSidebars)
                    {
                        if (!string.IsNullOrEmpty(sidebar.SidebarMenuIds))
                        {
                            result.SelectedSidebars = result.SelectedSidebars.Concat(sidebar.SidebarMenuIds.Split(new char[] { ',', ';' }).Select(e => Guid.Parse(e))).ToList();
                        }
                    }

                    return View(result);
                }
                else
                {
                    throw new Exception( string.Format(CoreErrorResource.ERROR_NOT_FOUND, id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePermitObject(PermitObjectDTO permitObject)
        {
            try
            {
                if (!TryValidateModel(permitObject))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(permitObject);
                }

                if (!VerifyCode(permitObject.Id, permitObject.Code))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, permitObject.Code));
                }

                bool exist = permitObjectService.Any(permitObject.Id);
                if (exist)
                {
                    var sidebars = GetPermitObjectSidebar();
                    permitObject.ToValue(sidebars);

                    PermitObjects saveObject = mapper.Map<PermitObjects>(permitObject);
                    int result = permitObjectService.Update(saveObject);
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception( string.Format(CoreErrorResource.ERROR_NOT_FOUND, permitObject.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(permitObject);
        }

        [HttpGet]
        public IActionResult NewPermitObject()
        {
            return View(new PermitObjectDTO()
            {
                Created = DateTime.Now,
                CreatedBy = LoginContext.Instance.CurrentUser.UserName,
                Id = Guid.NewGuid()
            });
        }

        [HttpPost]
        public IActionResult NewPermitObject(PermitObjectDTO permitObject)
        {
            try
            {
                if (!TryValidateModel(permitObject))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View(permitObject);
                }

                if (!VerifyCode(permitObject.Id, permitObject.Code))
                {
                    throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, permitObject.Code));
                }

                bool exist = permitObjectService.Any(permitObject.Id);
                if (!exist)
                {
                    var sidebars = GetPermitObjectSidebar();
                    permitObject.ToValue(sidebars);
                    PermitObjects saveObject = mapper.Map<PermitObjects>(permitObject);
                    int result = permitObjectService.Insert(saveObject);
                    if (result > 0)
                        return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception( string.Format(CoreErrorResource.ERROR_NOT_FOUND, permitObject.Id));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View(permitObject);
        }

        #region Private Method

        private IList<ControllerDTO> GetControllerFromAsembly()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Assembly[] assems = currentDomain.GetAssemblies();
            var controllers = new List<ControllerDTO>();
            foreach (Assembly assem in assems)
            {
                var controller = assem.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && !type.IsAbstract)
               .Select(e => new ControllerDTO()
               {
                   Id = e.Name.Replace("Controller", string.Empty),
                   Name = !string.IsNullOrEmpty(ReflectionUtils.GetClassDescription(e)) ? string.Format("{0} - {1}", e.Name, ReflectionUtils.GetClassDescription(e)).Replace("Controller", string.Empty) : string.Empty
               })
               .Where(e=> !string.IsNullOrEmpty(e.Name))
               .OrderBy(e => e.Name)
               .Distinct();
                controllers.AddRange(controller);
            }

            return controllers;
        }

        private IList<PermitObjectSidebarDTO> GetPermitObjectSidebar()
        {
            return coreSlidebarItemService.Queryable.Select(e => new PermitObjectSidebarDTO()
            {
                Id = e.Id,
                ModuleId = e.ModuleId,
                CreatedBy = LoginContext.Instance.CurrentUser.UserName,
            }).ToList();
        }

        #endregion
    }
}