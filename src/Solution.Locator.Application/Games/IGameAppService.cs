using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.Friend.Dto;
using Solution.Locator.Games.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solution.Locator.Games
{
    public interface IGameAppService : IAsyncCrudAppService<GameDto, int, PagedResultRequestDto, CreateGameDto, GameDto>
    {
        Task<ListResultDto<GameDto>> GetAll();

        Task<ICollection<GameDto>> GetGamesAvailable();

        Task<ICollection<GameDto>> GetGamesBorrow(int friendId);
    }
}
