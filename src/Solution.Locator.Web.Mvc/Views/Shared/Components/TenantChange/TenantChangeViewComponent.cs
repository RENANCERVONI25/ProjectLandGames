using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AutoMapper;
using Solution.Locator.Sessions;

namespace Solution.Locator.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : LocatorViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public TenantChangeViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = loginInfo.MapTo<TenantChangeViewModel>();
            return View(model);
        }
    }
}
