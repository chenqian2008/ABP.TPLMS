using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.TPLMS.Authorization;

namespace ABP.TPLMS
{
    [DependsOn(
        typeof(TPLMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TPLMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TPLMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TPLMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
