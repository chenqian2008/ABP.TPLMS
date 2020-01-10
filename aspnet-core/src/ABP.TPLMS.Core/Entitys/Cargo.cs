using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ABP.TPLMS.Entitys
{

    public class Cargo : Entity<int>, IHasCreationTime
    {

        public Cargo()
        {

            this.Id = 0;
            this.SupplierId = 0;
            this.CargoCode = string.Empty;
            this.CargoName = string.Empty;
            this.Brand = string.Empty;
            this.Country = string.Empty;
            this.CreationTime = DateTime.Now;
            this.Curr = string.Empty;

            this.GrossWt = 0;
            this.Height = 0;
            this.HSCode = string.Empty;
            this.Length = 0;

            this.MaxNum = 100;
            this.MinNum = 0;
            this.NetWt = 0;

            this.Package = string.Empty;
            this.Price = 0;
            this.Remark = string.Empty;

            this.Spcf = string.Empty;
            this.Unit = string.Empty;
            this.UpdateTime = DateTime.Now;

            this.UpdOper = string.Empty;
            this.Vol = 0;
            this.Width = 0;

        }



        public int SupplierId { get; set; }
        [StringLength(50)]
        public string CargoCode { get; set; }
        [StringLength(10)]
        public string HSCode { get; set; }

        [StringLength(250)]
        public string CargoName { get; set; }

        [StringLength(512)]
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