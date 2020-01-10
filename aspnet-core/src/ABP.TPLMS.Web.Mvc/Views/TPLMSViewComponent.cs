using Abp.AspNetCore.Mvc.ViewComponents;

namespace ABP.TPLMS.Web.Views
{
    public abstract class TPLMSViewComponent : AbpViewComponent
    {
        protected TPLMSViewComponent()
        {
            LocalizationSourceName = TPLMSConsts.LocalizationSourceName;
        }
    }
}
