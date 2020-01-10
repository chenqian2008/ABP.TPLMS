using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABP.TPLMS.Entitys
{
    public class Supplier : Entity<int>, IHasCreationTime
    {
        public const int MaxLength = 255;
        public Supplier()
        {

            this.Address = string.Empty;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Code = string.Empty;

            this.Sex = 0;
            this.LinkName = string.Empty;
            this.Status = 0;
            this.Tel = string.Empty;
            this.Mobile = string.Empty;
            this.UserId = 0;

            CreationTime = Clock.Now;
        }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Name { get; set; }

        [StringLength(MaxLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(MaxLength)]

        public string Email { get; set; }

        [StringLength(MaxLength)]
        public string LinkName { get; set; }
        public int Sex { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Tel { get; set; }
        [StringLength(MaxLength)]
        public string Mobile { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}