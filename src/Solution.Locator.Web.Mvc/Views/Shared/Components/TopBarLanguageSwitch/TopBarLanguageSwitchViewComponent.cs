using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Abp.Localization;

namespace Solution.Locator.Web.Views.Shared.Components.TopBarLanguageSwitch
{
    public class TopBarLanguageSwitchViewComponent : LocatorViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public TopBarLanguageSwitchViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public IViewComponentResult Invoke()
        {
            var model = new TopBarLanguageSwitchViewModel
            {
                CurrentLanguage = _languageManager.GetLanguages().Where(x=>x.Name =="pt-BR").FirstOrDefault(),
                Languages = _languageManager.GetLanguages().Where(l => !l.IsDisabled).ToList()
            };

            return View(model);
        }
    }
}
