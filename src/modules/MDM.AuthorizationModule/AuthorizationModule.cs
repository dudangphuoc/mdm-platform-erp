using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero;
using Abp.Zero.Configuration;
using Abp.Zero.EntityFrameworkCore;
using AuthorizationModule.Authorization;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using AuthorizationModule.MultiTenancy;
using MDM.Shared.Localization.AuthorizationModule;

namespace MDM.AuthorizationModule
{
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AuthorizationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MDMAuthorizationProvider>();

            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
            AuthorizationLocalizationConfigurer.Configure(Configuration.Localization);
            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AuthorizationModule).GetAssembly());

        }
    }
}