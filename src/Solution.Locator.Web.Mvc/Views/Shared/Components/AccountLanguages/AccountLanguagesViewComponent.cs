using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Localization;

namespace Solution.Locator.Web.Views.Shared.Components.AccountLanguages
{
    public class AccountLanguagesViewComponent : LocatorViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public AccountLanguagesViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.GetLanguages().Where(x=>x.Name == "pt-BR").First(),
                Languages = _languageManager.GetLanguages().Where(l => !l.IsDisabled).ToList()
                .Where(l => !l.IsDisabled)
                .ToList(),
                CurrentUrl = Request.Path
            };

            return Task.FromResult(View(model) as IViewComponentResult);
        }
    }
}
