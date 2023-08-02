using Abp.Application.Services;
using AuthorizationModule.DataTransferObject.Sessions;
using System.Threading.Tasks;

namespace AuthorizationModule.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
