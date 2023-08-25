using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.Shared;

namespace MDM.ModuleBase;

[DependsOn(typeof(MDMSharedModule))]
public class MDMModuleBase : AbpModule
{
    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MDMModuleBase).GetAssembly());
    }
}