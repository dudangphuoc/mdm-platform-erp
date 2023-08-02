using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MDMPlatform;

namespace Identity.EntityFrameworkCore
{
    [DependsOn(
        typeof(MDMPlatformCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class MDMEntityFrameworkModule : AbpModule
    {

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDMEntityFrameworkModule).GetAssembly());
        }
    }
}
