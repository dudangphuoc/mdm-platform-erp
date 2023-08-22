using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyTypeApp;
public class PartyTypeService : AsyncCrudAppService<PartyType, PartyTypeModel, Guid, GetAllPartyTypeModel, CreatePartyTypeModel, UpdatePartyTypeModel, GetPartyTypeModel, DeletePartyTypeModel>, IPartyTypeService
{
    public PartyTypeService(IRepository<PartyType, Guid> repository) : base(repository)
    {
    }
}
