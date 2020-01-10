using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABP.TPLMS.Entitys
{
    public class Module : Entity, IHasCreationTime
    {

        public const int MaxLength = 255;
        public Module()
        {

            this.DisplayName = string.Empty;
            this.Name = string.Empty;
            this.Url = string.Empty;
            this.HotKey = string.Empty;
            this.ParentId = 0;
            this.IconName = string.Empty;
            this.Status = 0;
            this.ParentName = string.Empty;
            this.RequiredPermissionName = string.Empty;
            this.RequiresAuthentication = false;
            this.SortNo = 0;

            CreationTime = Clock.Now;
        }

        [Required]
        [StringLength(MaxLength)]
        public string DisplayName { get; set; }


        [Required]
        [StringLength(MaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Url { get; set; }


        [StringLength(MaxLength)]
        public string HotKey { get; set; }
        public int ParentId { get; set; }
        public bool RequiresAuthentication { get; set; }
        public bool IsAutoExpand { get; set; }

        [StringLength(MaxLength)]
        public string IconName { get; set; }
        public int Status { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string ParentName { get; set; }


        [StringLength(MaxLength)]
        public string RequiredPermissionName { get; set; }
        public int SortNo { get; set; }
        public DateTime CreationTime { get; set; }
    }
}