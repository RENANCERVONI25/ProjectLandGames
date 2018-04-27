using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Solution.Locator.Controllers
{
    public abstract class LocatorControllerBase: AbpController
    {
        protected LocatorControllerBase()
        {
            LocalizationSourceName = LocatorConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
