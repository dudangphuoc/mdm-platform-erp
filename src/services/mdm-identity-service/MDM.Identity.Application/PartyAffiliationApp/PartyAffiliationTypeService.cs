using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace Identity.Application.PartyAffiliationApp;

public class PartyAffiliationTypeService : AsyncCrudAppService<PartyAffiliationType, PartyAffiliationTypeModel, Guid, GetAllPartyAffiliationTypeModel, CreatePartyAffiliationTypeModel, UpdatePartyAffiliationTypeModel, GetPartyAffiliationTypeModel, DeletePartyAffiliationTypeModel>, IPartyAffiliationTypeService
{
    public PartyAffiliationTypeService(IRepository<PartyAffiliationType, Guid> repository) : base(repository)
    {
    }

    protected override IQueryable<PartyAffiliationType> CreateFilteredQuery(GetAllPartyAffiliationTypeModel input)
    {
        var query = base.CreateFilteredQuery(input);
        query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Name), x => x.Name.Contains(input.Name));

        return query;
    }
}

