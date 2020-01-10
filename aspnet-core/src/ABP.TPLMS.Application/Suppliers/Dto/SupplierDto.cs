using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Suppliers.Dto
{

    [AutoMapFrom(typeof(Entitys.Supplier))]
    public class SupplierDto : EntityDto<int>
    {

        public string Address { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Code { get; set; }
        public int Sex { get; set; }

        public string LinkName { get; set; }

        public int Status { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}