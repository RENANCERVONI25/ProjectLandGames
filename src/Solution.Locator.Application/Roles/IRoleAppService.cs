using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.Roles.Dto;

namespace Solution.Locator.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
