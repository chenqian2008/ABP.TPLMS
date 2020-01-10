using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace ABP.TPLMS.Web.Views
{
    public abstract class TPLMSRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TPLMSRazorPage()
        {
            LocalizationSourceName = TPLMSConsts.LocalizationSourceName;
        }
    }
}
