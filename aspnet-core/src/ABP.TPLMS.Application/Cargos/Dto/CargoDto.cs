using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Cargos.Dto
{

    [AutoMapFrom(typeof(Cargo))]
    public class CargoDto : EntityDto<int>
    {

        public int SupplierId { get; set; }
        public string CargoCode { get; set; }
        public string HSCode { get; set; }

        public string CargoName { get; set; }

        public string Spcf { get; set; }
        public string Unit { get; set; }
        public string Country { get; set; }

        public string Brand { get; set; }

        public string Curr { get; set; }
        public string Package { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }

        public decimal Height { get; set; }
        public decimal Vol { get; set; }

        public decimal MinNum { get; set; }
        public decimal MaxNum { get; set; }
        public decimal Price { get; set; }
        public decimal GrossWt { get; set; }

        public decimal NetWt { get; set; }

        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdOper { get; set; }

    }
}