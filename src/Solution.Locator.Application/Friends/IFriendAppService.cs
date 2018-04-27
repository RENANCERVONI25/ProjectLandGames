using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.Friend.Dto;
using System.Threading.Tasks;

namespace Solution.Locator.Friends
{
    public interface IFriendAppService : IAsyncCrudAppService<FriendDto, int, PagedResultRequestDto, CreateFriendDto, FriendDto>
    {
        Task<ListResultDto<FriendDto>> GetAll();
    }
}
