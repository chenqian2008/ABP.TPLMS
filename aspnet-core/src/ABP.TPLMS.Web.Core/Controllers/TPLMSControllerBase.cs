using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using ABP.TPLMS.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ABP.TPLMS.Controllers
{
    public abstract class TPLMSControllerBase: AbpController
    {
        protected TPLMSControllerBase()
        {
            LocalizationSourceName = TPLMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected dynamic JsonEasyUI(dynamic t, int total)
        {
            var obj = new
            {
                total = total,
                rows = t
            };
            var json = JsonHelper.Instance.Serialize(obj);
            return json;
        }

        protected dynamic JsonEasyUIResult(int id, string result)
        {

            string strId = string.Empty;
            if (id > 0)
            {
                strId = id.ToString();
            }

            var obj = new
            {
                result = result,
                Id = strId
            };
            var json = JsonHelper.Instance.Serialize(obj);
            return json;
        }
    }
}
