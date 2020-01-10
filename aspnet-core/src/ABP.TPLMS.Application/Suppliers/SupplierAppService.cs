using Abp.Application.Services;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Suppliers
{

    public class SupplierAppService : AsyncCrudAppService<Supplier, SupplierDto, int, PagedSupplierResultRequestDto,
                             CreateUpdateSupplierDto, CreateUpdateSupplierDto>, ISupplierAppService

    {

        public SupplierAppService(IRepository<Supplier, int> repository)
            : base(repository)
        {

        }

        public override Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input)
        {
            var sin = input;
            return base.CreateAsync(input);
        }
    }
}