using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyIdentificationTypeApp;

public interface IPartyIdentificationTypeService : IAsyncCrudAppService<PartyIdentificationTypeModel, Guid, GetAllPartyIdentificationTypeModel, CreatePartyIdentificationTypeModel, UpdatePartyIdentificationTypeModel, GetPartyIdentificationTypeModel, DeletePartyIdentificationTypeModel>
{

}

