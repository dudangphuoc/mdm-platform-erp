using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyAffiliation;

public interface IPartyAffiliationTypeService : IAsyncCrudAppService<PartyAffiliationTypeModel, Guid, GetAllPartyAffiliationTypeModel, CreatePartyAffiliationTypeModel, UpdatePartyAffiliationTypeModel, GetPartyAffiliationTypeModel, DeletePartyAffiliationTypeModel>
{

}

