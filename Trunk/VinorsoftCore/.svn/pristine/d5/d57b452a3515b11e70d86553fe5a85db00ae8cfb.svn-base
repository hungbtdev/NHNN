using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Models.Search;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    [Authorize]
    [KTAppAuthorize2(permission: new string[] { CoreConstants.View })]
    public class OrgChartCoreController : KTAppCore2Controller<Departments, DepartmentModel, SearchOrgChartModel>
    {
        readonly IDepartmentService departmentService;
        public OrgChartCoreController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            departmentService = serviceProvider.GetRequiredService<IDepartmentService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            domainService = departmentService;
        }

        [HttpGet]
        public virtual ActionResult<KTAppDomainResult> GetNodeByParentId([FromQuery] Guid? parentId)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                if (parentId.HasValue)
                {
                    appDomainResult.Data = departmentService.Get(e => !e.Deleted && e.ParentId == parentId.Value);
                    appDomainResult.Success = true;
                }
                else
                {
                    var rootNodes = departmentService.Get(e => !e.Deleted && !e.ParentId.HasValue);
                    var rootNodeIds = rootNodes.Select(e => e.Id);
                    IList<DepartmentModel> results = new List<DepartmentModel>();
                    foreach (var item in rootNodes)
                    {
                        var dept = mapper.Map<DepartmentModel>(item);
                        dept.Nodes = departmentService.Get(e => !e.Deleted && rootNodeIds.Contains(e.ParentId.Value));
                        results.Add(dept);
                    }
                    appDomainResult.Data = results;
                    appDomainResult.Success = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }
            return appDomainResult;
        }

        [HttpPost]
        public virtual ActionResult<KTAppDomainResult> GetUserByDepartment([FromBody] SearchUserModel searchUser)
        {
            KTAppDomainResult appDomainResult = new KTAppDomainResult();
            try
            {
                Expression<Func<Users, Users>> select = e => new Users()
                {
                    Active = e.Active,
                    Username = e.Username,
                    Id = e.Id,
                    UserDepartments = e.UserDepartments.Select(d => new UserDepartments()
                    {
                        Departments = d.Departments,
                        JobTitles = d.JobTitles
                    }).ToList(),
                };
                Expression<Func<Users, bool>> condition = e => !e.Deleted && e.UserDepartments.Any(d => d.DepartmentId == searchUser.DepartmentId);
                var results = userService.Get(condition, select, searchUser.PageIndex, searchUser.PageSize, searchUser.OrderBy);
                appDomainResult.Data = results;
                appDomainResult.Success = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }

            return appDomainResult;
        }
    }
}