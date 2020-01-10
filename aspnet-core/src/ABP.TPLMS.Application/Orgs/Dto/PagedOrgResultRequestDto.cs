using Abp.Application.Services.Dto;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;


namespace ABP.TPLMS.Orgs.Dto
{

    public class PagedOrgResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}