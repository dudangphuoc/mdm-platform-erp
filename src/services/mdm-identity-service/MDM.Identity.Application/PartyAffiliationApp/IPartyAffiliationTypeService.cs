using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyAffiliationApp;

public interface IPartyAffiliationTypeService : IAsyncCrudAppService<PartyAffiliationTypeModel, Guid, GetAllPartyAffiliationTypeModel, CreatePartyAffiliationTypeModel, UpdatePartyAffiliationTypeModel, GetPartyAffiliationTypeModel, DeletePartyAffiliationTypeModel>
{

}

