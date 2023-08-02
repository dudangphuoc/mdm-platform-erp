using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Identity.Application.Configuration.Dto;
using MDMPlatform.Configuration;

namespace Identity.Application.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdentityAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
