using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.AttachedGames.Dto;
using Solution.Locator.Friend.Dto;
using System.Threading.Tasks;

namespace Solution.Locator.AttachedGames
{
    public interface IAttachedAppService : IApplicationService
    {
        Task Attached(AttachedGamesDto input);
    }
}
