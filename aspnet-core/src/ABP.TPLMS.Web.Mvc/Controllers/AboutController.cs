using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ABP.TPLMS.Controllers;

namespace ABP.TPLMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TPLMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
