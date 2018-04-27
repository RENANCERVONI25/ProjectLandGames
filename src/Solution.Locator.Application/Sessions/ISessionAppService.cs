using System.Threading.Tasks;
using Abp.Application.Services;
using Solution.Locator.Sessions.Dto;

namespace Solution.Locator.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
