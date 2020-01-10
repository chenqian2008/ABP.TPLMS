using Abp.AutoMapper;
using ABP.TPLMS.Sessions.Dto;

namespace ABP.TPLMS.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
