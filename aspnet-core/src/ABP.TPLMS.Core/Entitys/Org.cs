using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ABP.TPLMS.Entitys
{

    public partial class Org : Entity<int>, IHasCreationTime
    {
        int m_parentId = 0;
        public Org()
        {

            this.Id = 0;
            this.Name = string.Empty;
            this.HotKey = string.Empty;
            this.ParentId = 0;
            this.ParentName = string.Empty;

            this.IconName = string.Empty;

            this.Status = 0;

            this.Type = 0;

            this.BizCode = string.Empty;
            this.CustomCode = string.Empty;
            this.CreationTime = DateTime.Now;
            this.UpdateTime = DateTime.Now;
            this.CreateId = 0;

            this.SortNo = 0;

        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string HotKey { get; set; }

        public int ParentId { get { return m_parentId; } set { m_parentId = value; } }

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
        public int? _parentId
        {
            get
            {
                if (m_parentId == 0)
                {
                    return null;
                }

                return m_parentId;
            }

        }
    }
}