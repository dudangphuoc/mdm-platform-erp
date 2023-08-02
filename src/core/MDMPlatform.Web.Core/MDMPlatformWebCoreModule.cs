using Abp.AspNetCore;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MDMPlatform
{
    [DependsOn(
         typeof(MDMPlatformApplicationModule),
         typeof(MDMEntityFrameworkModule),
         typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreSignalRModule)
     )]
    public class MDMPlatformWebCoreModule : AbpModule
    {
        //private readonly IWebHostEnvironment _env;
        //private readonly IConfigurationRoot _appConfiguration;

        //public MDMPlatformWebCoreModule(IWebHostEnvironment env)
        //{
        //    _env = env;
        //    _appConfiguration = env.GetAppConfiguration();
        //}

        //public override void PreInitialize()
        //{
        //    Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
        //        MDMPlatformConsts.ConnectionStringName
        //    );

        //    // Use database for language management
        //    Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

        //    Configuration.Modules.AbpAspNetCore()
        //         .CreateControllersForAppServices(
        //             typeof(MDMPlatformApplicationModule).GetAssembly()
        //         );

        //    ConfigureTokenAuth();
        //}

        //private void ConfigureTokenAuth()
        //{
        //    IocManager.Register<TokenAuthConfiguration>();
        //    var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

        //    tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
        //    tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
        //    tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
        //    tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
        //    tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        //}

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDMPlatformWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MDMPlatformWebCoreModule).Assembly);
        }
    }
}
