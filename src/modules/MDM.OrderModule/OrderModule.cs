using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MDM.OrderModule;

public class OrderModule : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(OrderModule).GetAssembly());
    }
}