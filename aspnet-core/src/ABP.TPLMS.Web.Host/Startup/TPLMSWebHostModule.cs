using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.TPLMS.Configuration;

namespace ABP.TPLMS.Web.Host.Startup
{
    [DependsOn(
       typeof(TPLMSWebCoreModule))]
    public class TPLMSWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TPLMSWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TPLMSWebHostModule).GetAssembly());
        }
    }
}
