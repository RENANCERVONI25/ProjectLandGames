using Abp.AspNetCore.Mvc.ViewComponents;

namespace Solution.Locator.Web.Views
{
    public abstract class LocatorViewComponent : AbpViewComponent
    {
        protected LocatorViewComponent()
        {
            LocalizationSourceName = LocatorConsts.LocalizationSourceName;
        }
    }
}
