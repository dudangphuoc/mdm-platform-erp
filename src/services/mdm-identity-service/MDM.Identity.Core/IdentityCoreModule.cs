using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.CatalogModule;
using MDM.CommonModule;
using MDM.CustomerModule;
using MDM.OrderModule;
using MDM.PaymentModule;
using MDMPlatform;

namespace Identity.Core
{
    [DependsOn(
        typeof(MDM.AuthorizationModule.AuthorizationModule),
        typeof(MDMPlatformCoreModule),
        typeof(CatalogModule),
        typeof(CommonModule),
        typeof(CustomerModule),
        typeof(OrderModule),
        typeof(PaymentModule)
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
