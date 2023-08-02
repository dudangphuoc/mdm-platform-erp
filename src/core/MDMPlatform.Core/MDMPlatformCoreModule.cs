using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using MDM.Shared.AuthorizationModule;
using MDMPlatform.Configuration;
using MDMPlatform.Timing;

namespace MDMPlatform
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MDMPlatformCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<AppSettingProvider>();
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = GlobalConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = GlobalConsts.DefaultPassPhrase;

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = GlobalConsts.MultiTenancyEnabled;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDMPlatformCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
