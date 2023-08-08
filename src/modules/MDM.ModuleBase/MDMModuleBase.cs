using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MDM.ModuleBase;

public class MDMModuleBase : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MDMModuleBase).GetAssembly());
    }
}