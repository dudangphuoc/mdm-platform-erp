using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MDMPlatform
{
    [DependsOn(
        typeof(MDMPlatformCoreModule),
        typeof(AbpAutoMapperModule))]
    public class MDMPlatformApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MDMPlatformApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
