using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.ModuleBase;

namespace MDM.CommonModule
{
    [DependsOn()]
    public class CommonModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CommonModule).GetAssembly());
        }
    }
}