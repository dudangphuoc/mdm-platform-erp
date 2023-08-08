using Abp.Modules;
using Abp.Reflection.Extensions;
using MDM.ModuleBase;

namespace MDM.CatalogModule
{
    [DependsOn(typeof(MDMModuleBase))]
    public class CatalogModule : AbpModule
    {
        public override void PreInitialize()
        {
            
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CatalogModule).GetAssembly());
        }
    }
}