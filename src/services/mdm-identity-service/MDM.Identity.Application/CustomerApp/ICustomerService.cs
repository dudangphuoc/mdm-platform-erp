using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public interface ICustomerService : IApplicationService
{
    Task<PartyModel> CreateAsync(CreatePartyModel input);
    Task<PartyModel> CreatePersonAsync(CreatePartyModel input);
    Task<PagedResultDto<PartySearchModel>> GetAllAsync(GetAllCustomerModel input);
    Task<PartyModel> GetAsync(GetPartyModel input);
    Task<PartyModel> UpdateAsync(UpdatePartyModel input);
}

