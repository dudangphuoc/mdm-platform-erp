using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.ModuleBase;

namespace MDM.CustomerModule
{
    [DependsOn(typeof(MDMModuleBase))]
    public class CustomerModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CustomerModule).GetAssembly());
        }
    }
}