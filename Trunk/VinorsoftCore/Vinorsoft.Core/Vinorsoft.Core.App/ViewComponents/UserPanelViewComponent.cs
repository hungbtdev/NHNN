using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.App.ViewComponents
{
    [ViewComponent]
    public class UserPanelViewComponent : ViewComponent
    {
        public UserPanelViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserPanelDTO userPanel = new UserPanelDTO();
            if (LoginContext.Instance.CurrentUser != null)
            {
                userPanel.IsAuthorized = true;
                userPanel.FullName = LoginContext.Instance.CurrentUser.FullName;
            }

            return await Task.FromResult((IViewComponentResult)View("_UserPanel", userPanel));
        }
    }
}
