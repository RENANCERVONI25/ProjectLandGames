using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Solution.Locator.MultiTenancy.Dto;

namespace Solution.Locator.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
