using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.ModuleBase;

namespace MDM.PaymentModule;

[DependsOn(typeof(MDMModuleBase))]
public class PaymentModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(PaymentModule).GetAssembly());
    }
}