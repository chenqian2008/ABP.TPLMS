using System.Collections.Generic;
using ABP.TPLMS.Suppliers.Dto;

namespace ABP.TPLMS.Web.Models.Supplier
{

    public class SupplierListViewModel
    {
        public SupplierDto Supplier { get; set; }
        public IReadOnlyList<SupplierDto> Suppliers { get; set; }
    }
}