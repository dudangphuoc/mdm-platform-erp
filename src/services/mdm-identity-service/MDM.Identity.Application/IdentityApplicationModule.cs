using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Identity.Core;

namespace Identity.Application
{

    [DependsOn(
        typeof(IdentityCoreModule),
        typeof(AbpAutoMapperModule))]
    public class IdentityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
   
}
