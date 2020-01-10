using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ABP.TPLMS.Controllers;

namespace ABP.TPLMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TPLMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
