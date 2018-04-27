using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.Roles.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
