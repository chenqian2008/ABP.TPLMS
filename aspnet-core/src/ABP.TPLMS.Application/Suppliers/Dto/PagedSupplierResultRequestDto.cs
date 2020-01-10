using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;


namespace ABP.TPLMS.Suppliers.Dto
{
    public class PagedSupplierResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}