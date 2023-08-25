using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MDM.Shared;
public class MDMSharedModule : AbpModule
{
    public override void Initialize()
    {
        var thisAssembly = typeof(MDMSharedModule).GetAssembly();
        IocManager.RegisterAssemblyByConvention(thisAssembly);

    }
}
