using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Models;

namespace Identity.Application.TeamApp;

public class TeamService : AsyncCrudAppService<Team, TeamModel, Guid, GetAllTeamModel, CreateTeamModel, UpdateTeamModel, GetTeamModel, DeleteTeamModel>, ITeamService
{
    public TeamService(IRepository<Team, Guid> repository) : base(repository)
    {

    }
}

