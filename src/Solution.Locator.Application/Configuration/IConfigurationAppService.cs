using System.Threading.Tasks;
using Solution.Locator.Configuration.Dto;

namespace Solution.Locator.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
