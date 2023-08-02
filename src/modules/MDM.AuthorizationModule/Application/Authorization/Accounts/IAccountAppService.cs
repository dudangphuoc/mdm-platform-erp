using Abp.Application.Services;
using AuthorizationModule.DataTransferObject.Accounts;
using System.Threading.Tasks;

namespace AuthorizationModule.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
