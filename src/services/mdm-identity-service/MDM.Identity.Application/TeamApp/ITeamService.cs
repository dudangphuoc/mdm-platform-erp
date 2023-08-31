using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.TeamApp;

public interface ITeamService : IAsyncCrudAppService<TeamModel, Guid, GetAllTeamModel, CreateTeamModel, UpdateTeamModel, GetTeamModel, DeleteTeamModel>
{

}

