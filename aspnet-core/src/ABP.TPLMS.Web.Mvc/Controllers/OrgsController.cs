using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Orgs;
using ABP.TPLMS.Orgs.Dto;
using ABP.TPLMS.Web.Models.Orgs;
using Microsoft.AspNetCore.Mvc;


namespace ABP.TPLMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class OrgsController : TPLMSControllerBase
    {
        private readonly IOrgAppService _orgAppService;
        private const int MAX_COUNT = 1000;

        public OrgsController(IOrgAppService orgAppService)
        {
            _orgAppService = orgAppService;
        }
        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [DontWrapResult]
        [HttpPost]
        public string List()
        {
            PagedOrgResultRequestDto paged = new PagedOrgResultRequestDto();
            paged.MaxResultCount = MAX_COUNT;
            var orgList = _orgAppService.GetAllAsync(paged).GetAwaiter().GetResult().Items;
            int total = orgList.Count;
            var json = JsonEasyUI(orgList, total);

            return json;
        }
    }
}