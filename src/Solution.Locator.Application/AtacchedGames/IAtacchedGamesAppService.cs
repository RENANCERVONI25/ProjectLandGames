using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.AtacchedGames.Dto;
using Solution.Locator.Friend.Dto;
using System.Threading.Tasks;

namespace Solution.Locator.AtacchedGames
{
    public interface IAtacchedAppService : IApplicationService
    {
        Task Atacched(AttachedGamesDto input);
    }
}
