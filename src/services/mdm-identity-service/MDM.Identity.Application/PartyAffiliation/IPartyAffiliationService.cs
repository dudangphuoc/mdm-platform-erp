using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyAffiliation;

public interface IPartyAffiliationService : IAsyncCrudAppService<PartyAffiliationModel, Guid, GetAllPartyAffiliationModel, CreatePartyAffiliationModel, UpdatePartyAffiliationModel, GetPartyAffiliationModel, DeletePartyAffiliationModel>
{

}

