using System.Threading.Tasks;
using Identity.Application.Configuration.Dto;

namespace Identity.Application.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
