using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.Utils;
using KTApps.Domain;
using KTApps.Models;
using KTApps.ShareService.Entities;
using KTApps.ShareService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class PermitObjectCoreController : CatalogueCoreController<PermitObjects, PermitObjectModel, SearchCatalogueModel>
    {
        readonly ICoreSlidebarItemService coreSlidebarItemService;
        readonly ICoreModuleService coreModuleService;
        public PermitObjectCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            coreSlidebarItemService = serviceProvider.GetRequiredService<ICoreSlidebarItemService>();
            coreModuleService = serviceProvider.GetRequiredService<ICoreModuleService>();
            catalogueService = serviceProvider.GetRequiredService<IPermitObjectService>();
            domainService = catalogueService;
        }

        public override IActionResult NewItem()
        {
            return View();
        }

        public override IActionResult UpdateItem(Guid id)
        {
            return View();
        }

        public override ActionResult<KTAppDomainResult> Save([FromBody] PermitObjectModel permitObject)
        {
            permitObject.ToModel();
            if (permitObject.PermitObjectSidebars.Count > 0)
            {
                foreach (var pObj in permitObject.PermitObjectSidebars)
                {
                    pObj.ToModel();
                }
            }

            return base.Save(permitObject);
        }

        public override ActionResult<KTAppDomainResult> GetById([FromQuery] Guid? id)
        {
            KTAppDomainResult domainResult = new KTAppDomainResult();
            try
            {
                PermitObjectModel permitObject = null;
                var modules = coreModuleService.Get(e => !e.Deleted).ToList();
                if (id.HasValue)
                {
                    var doc = catalogueService.GetById(id.Value, e => new PermitObjects()
                    {
                        Active = e.Active,
                        Code = e.Code,
                        ControllerNames = e.ControllerNames,
                        Created = e.Created,
                        CreatedBy = e.CreatedBy,
                        Deleted = e.Deleted,
                        Description = e.Description,
                        Id = e.Id,
                        Name = e.Name,
                        Updated = e.Updated,
                        UpdatedBy = e.UpdatedBy,
                        PermitObjectSidebars = e.PermitObjectSidebars.Where(x => !x.Deleted).ToList()
                    });
                    if (doc != null)
                    {
                        permitObject = mapper.Map<PermitObjectModel>(doc);
                        permitObject.Toview();
                        var newModule = modules.Where(e => !permitObject.PermitObjectSidebars.Any(p => p.ModuleId == e.Id && !e.Deleted))
                        .Select(e => new PermitObjectSidebarModel()
                        {
                            Id = Guid.NewGuid(),
                            ModuleId = e.Id,
                            PermitObjectId = permitObject.Id,
                            SidebarMenuIds = string.Empty
                        }).ToList();

                        if (newModule.Count > 0)
                        {
                            permitObject.PermitObjectSidebars = permitObject.PermitObjectSidebars.Concat(newModule).ToList();
                        }

                        if (permitObject.PermitObjectSidebars.Count > 0)
                        {
                            foreach (var pObj in permitObject.PermitObjectSidebars)
                            {
                                pObj.Toview();
                            }
                        }
                        var moduleIds = permitObject.PermitObjectSidebars.Select(e => e.ModuleId).ToList();
                        foreach (var item in modules)
                        {
                            if (moduleIds.Contains(item.Id))
                                continue;
                            PermitObjectSidebarModel permitObjectSidebarModel = new PermitObjectSidebarModel()
                            {
                                Id = Guid.NewGuid(),
                                ModuleId = item.Id,
                                PermitObjectId = permitObject.Id,
                                SidebarMenuIds = string.Empty
                            };
                            permitObject.PermitObjectSidebars.Add(permitObjectSidebarModel);
                        }
                    }
                }
                else
                {
                    var permitObjectId = Guid.NewGuid();
                    permitObject = new PermitObjectModel()
                    {
                        Id = permitObjectId,
                        Active = true,
                        PermitObjectSidebars = modules
                        .Select(e => new PermitObjectSidebarModel()
                        {
                            Id = Guid.NewGuid(),
                            ModuleId = e.Id,
                            PermitObjectId = permitObjectId,
                            SidebarMenuIds = string.Empty
                        }).ToList()
                    };
                }
                domainResult.Data = permitObject;
                domainResult.Success = true;

                return new KTAppDomainResult()
                {
                    Success = true,
                    Data = permitObject
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                domainResult.Success = true;
                domainResult.Messages.Add(ex.Message);
            }

            return domainResult;
        }

        public override ActionResult<KTAppDomainResult> InitDropdown()
        {
            KTAppDomainResult domainResult = new KTAppDomainResult();
            try
            {
                var module = coreModuleService.Get(e => !e.Deleted)
                    .Select(e => new
                    {
                        Id = e.Id.ToString(),
                        e.Name
                    }).ToList();

                AppDomain currentDomain = AppDomain.CurrentDomain;
                Assembly[] assems = currentDomain.GetAssemblies();
                var controllers = new List<object>();
                foreach (Assembly assem in assems)
                {
                    var controller = assem.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && !type.IsAbstract)
                  .Select(e => new 
                  {
                      Id = e.Name.Replace("Controller", string.Empty),
                      Name = string.Format("{0} - {1}", e.Name, ReflectionUtils.GetClassDescription(e)).Replace("Controller", string.Empty)
                  })  .OrderBy(e => e.Name)
                      .Distinct();

                    controllers.AddRange(controller);
                }

                domainResult.Data = new
                {
                    SidebarItems = coreSlidebarItemService.Get(e => !e.Deleted, e => new CoreSlidebarItems()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Code = e.Code,
                        Description = e.Description,
                        ModuleId = e.ModuleId,
                        CoreModules = new CoreModules()
                        {
                            Name = e.CoreModules.Name,
                        },
                    })
                    .OrderBy(e => e.Name)
                    .ToList(),
                    Modules = module,
                    Controllers = controllers
                };
                domainResult.Success = true;
            }
            catch (Exception ex)
            {
                domainResult.Messages.Add(ex.Message);
            }
            return domainResult;
        }

    }
}