using Microsoft.AspNetCore.Antiforgery;
using ABP.TPLMS.Controllers;

namespace ABP.TPLMS.Web.Host.Controllers
{
    public class AntiForgeryController : TPLMSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
