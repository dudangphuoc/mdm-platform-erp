using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MDMPlatform.Configuration;

namespace MDMPlatform.Web.Host.Startup
{
    [DependsOn(
       typeof(MDMPlatformWebCoreModule))]
    public class MDMPlatformWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MDMPlatformWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDMPlatformWebHostModule).GetAssembly());
        }
    }
}
