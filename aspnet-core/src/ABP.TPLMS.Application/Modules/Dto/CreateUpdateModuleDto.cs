using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABP.TPLMS.Modules.Dto
{
    [AutoMapTo(typeof(Module))] //定义单向映射
    public class CreateUpdateModuleDto : EntityDto<long>
    {

        public const int MaxLength = 255;

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
    }
}
