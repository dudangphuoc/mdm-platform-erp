using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyRoleTypeApp;

public interface IPartyRoleTypeService : IAsyncCrudAppService<PartyRoleTypeModel, Guid, GetAllPartyRoleTypeModel, CreatePartyRoleTypeModel, UpdatePartyRoleTypeModel, GetPartyRoleTypeModel, DeletePartyRoleTypeModel>
{

}

