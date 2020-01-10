using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Validation;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Cargos;
using ABP.TPLMS.Cargos.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abp.Web.Models;
using AutoMapper;

namespace ABP.TPLMS.Web.Controllers
{

    [AbpMvcAuthorize]
    public class CargoController : TPLMSControllerBase
    {
        const int MaxNum = 10;
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewData["SupplierId"] = "100001";
            return View();
        }

        private readonly ICargoAppService _cargoAppService;

        public CargoController(ICargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;

        }

        [DontWrapResult]
        public string List()
        {

            var page = Request.Form["page"].ToString();
            var size = Request.Form["rows"].ToString();
            int pageIndex = page == null ? 1 : int.Parse(page);
            int pageSize = size == null ? 20 : int.Parse(size);
            PagedCargoResultRequestDto paged = new PagedCargoResultRequestDto();
            paged.MaxResultCount = pageSize;
            paged.SkipCount = ((pageIndex - 1) < 0 ? 0 : pageIndex - 1) * pageSize;
            paged.CargoName = Request.Form["Name"].ToString();
            paged.CargoCode = Request.Form["Code"].ToString();
            paged.HsCode = Request.Form["HsCode"].ToString();

            var cargoList = _cargoAppService.GetAllAsync(paged).GetAwaiter().GetResult().Items;
            int total = _cargoAppService.GetAllAsync(paged).GetAwaiter().GetResult().TotalCount; //1000;
            var json = JsonEasyUI(cargoList, total);
            return json;

        }


        [HttpPost]
        [DisableValidation]
        public ActionResult Add(CargoDto createDto)
        {
            var json = string.Empty;
            string result = "NO";
            if (createDto == null)
            {
                json = JsonEasyUIResult(0, result);
                return Content(json);

            }
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoDto, CreateUpdateCargoDto>());
                var mapper = config.CreateMapper();
                var cargo = mapper.Map<CreateUpdateCargoDto>(createDto);


                var obj = _cargoAppService.CreateAsync(cargo);
                int id = obj.GetAwaiter().GetResult().Id;
                if (obj != null)
                {
                    json = JsonEasyUIResult(id, "OK");

                }
                else

                {
                    json = JsonEasyUIResult(0, result);

                }
            }
            catch (Exception ex)
            {
            }
            return Content(json);

        }

        [HttpPost]
        [DisableValidation]
        public ActionResult Update(CreateUpdateCargoDto updateDto)
        {
            var json = string.Empty;
            string result = "NO";

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoDto, CreateUpdateCargoDto>());
                var mapper = config.CreateMapper();
                var cargo = mapper.Map<CreateUpdateCargoDto>(updateDto);

                var obj = _cargoAppService.UpdateAsync(updateDto);
                int id = obj.GetAwaiter().GetResult().Id;

                if (obj != null)
                {
                    json = JsonEasyUIResult(id, "OK");

                }
                else

                {
                    json = JsonEasyUIResult(0, result);

                }
            }
            catch (Exception ex)
            {

            }

            return Content(json);

        }

        public ActionResult Delete(string ids)
        {
            string result = "NO";

            try
            {
                result = _cargoAppService.Delete(ids);
            }
            catch
            {

            }

            return Content(result);
        }
    }
}