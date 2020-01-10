using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABP.TPLMS.Cargos.Dto
{

    [AutoMapTo(typeof(Cargo))]
    public class CreateUpdateCargoDto : EntityDto<int>
    {

        public int SupplierId { get; set; }
        [StringLength(50)]
        public string CargoCode { get; set; }

        [StringLength(10)]
        public string HSCode { get; set; }

        [StringLength(250)]
        public string CargoName { get; set; }

        [StringLength(512)]
        public string Spcf { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }
        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(20)]
        public string Curr { get; set; }

        [StringLength(50)]
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
        [StringLength(2048)]
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
        [StringLength(50)]
        public string UpdOper { get; set; }
    }
}