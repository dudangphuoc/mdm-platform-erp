using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.Identity.Html;

namespace SelfHost.Startup
{
    [DependsOn(
       typeof(IdentityHtmlModule))]
    public class SelfHostModule : AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(SelfHostModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                }
            );
        }
      
    }
}
