using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyRoleTypeApp;

public class PartyRoleTypeService : AsyncCrudAppService<PartyRoleType, PartyRoleTypeModel, Guid, GetAllPartyRoleTypeModel, CreatePartyRoleTypeModel, UpdatePartyRoleTypeModel, GetPartyRoleTypeModel, DeletePartyRoleTypeModel>, IPartyRoleTypeService
{
    public PartyRoleTypeService(IRepository<PartyRoleType, Guid> repository) : base(repository)
    {

    }
}

