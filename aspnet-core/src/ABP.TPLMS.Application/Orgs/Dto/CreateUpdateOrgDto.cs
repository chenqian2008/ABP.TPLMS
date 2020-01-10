using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ABP.TPLMS.Orgs.Dto
{

    [AutoMapTo(typeof(Org))]
    public class CreateUpdateOrgDto : EntityDto<int>
    {

        public string Name { get; set; }
        [StringLength(255)]
        public string HotKey { get; set; }

        public int ParentId { get; set; }

        [Required]
        [StringLength(255)]
        public string ParentName { get; set; }

        public bool IsLeaf { get; set; }
        public bool IsAutoExpand { get; set; }

        [StringLength(255)]
        public string IconName { get; set; }

        public int Status { get; set; }
        public int Type { get; set; }

        [StringLength(255)]
        public string BizCode { get; set; }

        [StringLength(100)]
        public string CustomCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public int CreateId { get; set; }
        public int SortNo { get; set; }

    }
}