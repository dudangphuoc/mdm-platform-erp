using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AuthorizationModule.Authorization.Users;
using Identity.Application.PartyAffiliationApp;
using Identity.Core;
using MDM.CustomerModule.Models;

namespace Identity.Application
{

    [DependsOn(
        typeof(IdentityCoreModule),
        typeof(AbpAutoMapperModule))]
    public class IdentityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<MDM.CustomerModule.Entity.PartyModel.PartyAffiliation, PartyAffiliationModel>()
                    .ForMember(x => x.PartyName, opt => opt.MapFrom(s => s.Party.FullName))
                    .ForMember(x => x.SubPartyName, opt => opt.MapFrom(s => s.SubParty.FullName));
            });


            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
   
}
