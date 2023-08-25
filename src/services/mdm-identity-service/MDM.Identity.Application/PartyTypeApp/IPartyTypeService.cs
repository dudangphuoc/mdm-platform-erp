using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyTypeApp;

public interface IPartyTypeService : IAsyncCrudAppService<PartyTypeModel, Guid, GetAllPartyTypeModel, CreatePartyTypeModel, UpdatePartyTypeModel, GetPartyTypeModel, DeletePartyTypeModel>
    {
    }
