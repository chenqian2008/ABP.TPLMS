using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABP.TPLMS.MultiTenancy.Dto;

namespace ABP.TPLMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

