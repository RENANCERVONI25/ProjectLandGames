using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Solution.Locator.Configuration.Dto;

namespace Solution.Locator.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LocatorAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
