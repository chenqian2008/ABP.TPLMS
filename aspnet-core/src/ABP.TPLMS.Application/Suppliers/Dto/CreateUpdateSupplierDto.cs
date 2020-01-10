using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ABP.TPLMS.Entitys;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ABP.TPLMS.Suppliers.Dto
{

    [AutoMapTo(typeof(Supplier))]
    public class CreateUpdateSupplierDto : EntityDto<int>
    {

        public const int MaxLength = 255;
        [StringLength(MaxLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        public int Sex { get; set; }

        [StringLength(MaxLength)]
        public string LinkName { get; set; }
        public int Status { get; set; }

        [Required]
        [StringLength(MaxLength)]
        public string Tel { get; set; }

        [StringLength(MaxLength)]
        public string Mobile { get; set; }
    }
}