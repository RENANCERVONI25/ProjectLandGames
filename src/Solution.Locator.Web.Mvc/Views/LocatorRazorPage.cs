using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Solution.Locator.Web.Views
{
    public abstract class LocatorRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LocatorRazorPage()
        {
            LocalizationSourceName = LocatorConsts.LocalizationSourceName;
        }
    }
}
