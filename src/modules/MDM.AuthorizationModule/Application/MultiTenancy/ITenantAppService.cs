using Abp.Application.Services;
using AuthorizationModule.DataTransferObject.MultiTenancy;

namespace AuthorizationModule.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

