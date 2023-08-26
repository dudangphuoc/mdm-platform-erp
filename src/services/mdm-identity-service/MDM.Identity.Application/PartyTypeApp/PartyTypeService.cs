using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Application.PartyTypeApp;
public class PartyTypeService : AsyncCrudAppService<PartyType, PartyTypeModel, Guid, GetAllPartyTypeModel, CreatePartyTypeModel, UpdatePartyTypeModel, GetPartyTypeModel, DeletePartyTypeModel>, IPartyTypeService
{
    public PartyTypeService(IRepository<PartyType, Guid> repository) : base(repository)
    {
    }

    [AllowAnonymous]
    public override Task<PartyTypeModel> CreateAsync(CreatePartyTypeModel input)
    {
        return base.CreateAsync(input);
    }
}
