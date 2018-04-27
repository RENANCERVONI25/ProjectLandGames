using System.Threading.Tasks;
using Abp.Application.Services;
using Solution.Locator.Authorization.Accounts.Dto;

namespace Solution.Locator.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
