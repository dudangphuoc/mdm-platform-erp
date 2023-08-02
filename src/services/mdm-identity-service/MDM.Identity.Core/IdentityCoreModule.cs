using Abp.Modules;
using Abp.Reflection.Extensions;
using MDMPlatform;

namespace Identity.Core
{
    [DependsOn(
        typeof(MDM.AuthorizationModule.AuthorizationModule),
        typeof(MDMPlatformCoreModule)
        )]
    public class IdentityCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
