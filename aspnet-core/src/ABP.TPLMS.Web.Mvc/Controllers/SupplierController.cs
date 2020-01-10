using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Validation;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Suppliers;
using ABP.TPLMS.Suppliers.Dto;
using ABP.TPLMS.Web.Models.Supplier;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ABP.TPLMS.Web.Controllers
{

    [AbpMvcAuthorize]
    public class SupplierController : TPLMSControllerBase
    {
        const int MaxNum = 10;
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {

            var module = (await _supplierAppService.GetAllAsync(new PagedSupplierResultRequestDto { MaxResultCount = MaxNum })).Items;
            // Paging not implemented yet
            SupplierDto cuModule = null;
            if (module.Count > 0)
            {
                cuModule = module.First();
            }
            else
            {
                cuModule = new SupplierDto();
            }
            var model = new SupplierListViewModel
            {

                Supplier = cuModule,
                Suppliers = module

            };
            return View(model);
        }

        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;

        }
        public async Task<ActionResult> EditSupplierModal(int supplierId)

        {
            var supplier = await _supplierAppService.GetAsync(new EntityDto<int>(supplierId));

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SupplierDto, CreateUpdateSupplierDto>());
            var mapper = config.CreateMapper();

            CreateUpdateSupplierDto cuSupplier = mapper.Map<CreateUpdateSupplierDto>(supplier);
            var model = new EditSupplierModalViewModel
            {
                Supplier = supplier

            };
            return View("_EditSupplierModal", model);
        }
    }
}