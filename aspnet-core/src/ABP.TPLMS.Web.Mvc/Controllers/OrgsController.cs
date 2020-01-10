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



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860 

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
            var total = _orgAppService.GetAllAsync(paged).GetAwaiter().GetResult().TotalCount; //1000;

            var json = JsonEasyUI(orgList, total);
            return json;

        }

        [DontWrapResult]
        [HttpGet]
        public JsonResult GetJsonTree()
        {

            PagedOrgResultRequestDto paged = new PagedOrgResultRequestDto();

            paged.MaxResultCount = MAX_COUNT;
            var orglist = _orgAppService.GetAllAsync(paged).GetAwaiter().GetResult().Items;
            int total = _orgAppService.GetAllAsync(paged).GetAwaiter().GetResult().TotalCount; //1000;

            List<TreeJsonViewModel> list = LinqJsonTree(orglist, 0);

            return Json(list);

        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        //

        private List<TreeJsonViewModel> LinqJsonTree(IReadOnlyList<OrgDto> orgs, int parentId)
        {

            List<TreeJsonViewModel> jsonData = new List<TreeJsonViewModel>();
            List<OrgDto> classlist = orgs.Where(m => m.ParentId == parentId).ToList();

            classlist.ToList().ForEach(item =>
            {

                jsonData.Add(new TreeJsonViewModel
                {

                    id = item.Id,
                    children = LinqJsonTree(orgs, item.Id),
                    parentId = item.ParentId,
                    text = item.Name,
                    url = string.Empty,
                    state = parentId == 0 ? "open" : ""

                });
            });

            return jsonData;
        }
    }
}