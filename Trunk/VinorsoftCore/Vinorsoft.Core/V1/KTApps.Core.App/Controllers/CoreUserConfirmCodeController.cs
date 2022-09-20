using System;
using System.Linq;
using System.Linq.Expressions;
using KTApps.AuthService.Entities;
using KTApps.AuthService.Interface;
using KTApps.Core.App.Attribute;
using KTApps.Core.App.Models.Search;
using KTApps.Core.App.Utilities;
using KTApps.Domain;
using KTApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KTApps.Core.App.Controllers
{
    public abstract class CoreUserConfirmCodeController : KTAppCore2Controller<UserConfirmCodes, UserConfirmCodeModel, SearchUserConfirmModel>
    {

        protected readonly IUserConfirmTypeService userConfirmTypeService;
        protected readonly IUserConfirmStatusService userConfirmStatusService;
        public CoreUserConfirmCodeController(IServiceProvider serviceProvider, ILogger<KTAppCoreController> logger) : base(serviceProvider, logger)
        {
            domainService = serviceProvider.GetRequiredService<IUserConfirmCodeService>();
            userConfirmTypeService = serviceProvider.GetRequiredService<IUserConfirmTypeService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            userConfirmStatusService = serviceProvider.GetRequiredService<IUserConfirmStatusService>();
        }
        
        [HttpPost]
        [ActionName("Save")]
        [KTAppAuthorize2(permission: new string[] { CoreConstants.Edit, CoreConstants.AddNew })]
        public override ActionResult<KTAppDomainResult> Save([FromBody]UserConfirmCodeModel userConfirmCode)
        {
            KTAppDomainResult appResult = new KTAppDomainResult();
            try
            {
                if (ModelState.IsValid)
                {
                    if (userConfirmCode.Issued > userConfirmCode.Expired)
                    {
                        throw new Exception("Ngày cấp phải nhỏ hơn hoặc bằng ngày hết hạn");
                    }

                    // Có bất cứ mã nào còn hạn và trùng mã
                    var existsCode = domainService.Get(e => e.Expired <= DateTime.Now && e.Expired > userConfirmCode.Expired && !e.Deleted && e.ConfirmCode == userConfirmCode.ConfirmCode).Any();
                    if (existsCode)
                    {
                        throw new Exception("Mã đang được sử dụng");
                    }

                    UserConfirmCodes itemToSave = mapper.Map<UserConfirmCodes>(userConfirmCode);
                    bool success = domainService.Save(itemToSave);
                    appResult.Success = success;
                }
                else
                {
                    appResult.Messages = GetModelStateError();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, new string[] { });
                appResult.Messages.Add(ex.Message);
            }
            return appResult;
        }

        [HttpGet]
        [ActionName("InitDropdown")]
        public override ActionResult<KTAppDomainResult> InitDropdown()
        {

            return new KTAppDomainResult()
            {
                Success = true,
                Data = new
                {
                    UserConfirmStatus = userConfirmStatusService.Get(e => !e.Deleted).ToFilterList(),
                    UserConfirmTypes = userConfirmTypeService.Get(e => !e.Deleted).ToFilterList(),
                }
            };
        }

        protected override Expression<Func<UserConfirmCodes, UserConfirmCodes>> BuildSelectQuery()
        {
            return e => new UserConfirmCodes()
            {
                Active = e.Active,
                Id = e.Id,
                StatusId = e.StatusId,
                ConfirmCode = e.ConfirmCode,
                UserConfirmStatus = e.UserConfirmStatus,
                UserConfirmTypes = e.UserConfirmTypes,
                Expired = e.Expired,
                Issued = e.Issued,
                Users = new Users()
                {
                    FirstName = e.Users.FirstName,
                    LastName = e.Users.LastName,
                    Username = e.Users.Username,
                    Phone = e.Users.Phone,
                    Email = e.Users.Email
                }
            };
        }

    }
}