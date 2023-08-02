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
            IocManager.RegisterAssemblyByConvention(typeof(SelfHostModule).GetAssembly());
        }
    }
}
