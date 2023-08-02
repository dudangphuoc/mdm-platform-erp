using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using MDM.Shared.AuthorizationModule;
using Microsoft.AspNetCore.Identity;

namespace MDMPlatform.Controllers
{
    public abstract class MDMPlatformControllerBase : AbpController
    {
        protected MDMPlatformControllerBase()
        {
            LocalizationSourceName = GlobalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
