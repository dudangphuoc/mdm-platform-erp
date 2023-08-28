using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyAffiliationApp;

public interface IPartyAffiliationService : IAsyncCrudAppService<PartyAffiliationModel, Guid, GetAllPartyAffiliationModel, CreatePartyAffiliationModel, UpdatePartyAffiliationModel, GetPartyAffiliationModel, DeletePartyAffiliationModel>
{
    Task<bool> CreateOrDeleteAffiliationAgencyAsync(AffiliationAgencyModel input);
    Task<PagedResultDto<PartyAffiliationModel>> GetAllAffiliationAgencyAsync(GetAllPartyAffiliationModel input);
    Task<List<PartyAffiliationModel>> GetAllByHierarchicalAsync(GetAllByHierarchicalModel model);
    Task<PagedResultDto<PartyAffiliationModel>> GetAllSalesAsync(GetAllPartyAffiliationModel input);
    Task<PartyAffiliationModel> GetBySubPartyAsync(Guid partyId);
    List<PartyAffiliationModel> GetChildren(List<PartyAffiliationModel> categories, Guid parentId);
}

