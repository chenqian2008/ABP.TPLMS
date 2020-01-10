using Abp.Application.Services.Dto;

namespace ABP.TPLMS.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

