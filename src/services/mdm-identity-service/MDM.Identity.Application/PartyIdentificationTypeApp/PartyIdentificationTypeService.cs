using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyIdentificationTypeApp;

public class PartyIdentificationTypeService : AsyncCrudAppService<PartyIdentification, PartyIdentificationTypeModel, Guid, GetAllPartyIdentificationTypeModel, CreatePartyIdentificationTypeModel, UpdatePartyIdentificationTypeModel, GetPartyIdentificationTypeModel, DeletePartyIdentificationTypeModel>, IPartyIdentificationTypeService
{
    public PartyIdentificationTypeService(IRepository<PartyIdentification, Guid> repository) : base(repository)
    {

    }
}

