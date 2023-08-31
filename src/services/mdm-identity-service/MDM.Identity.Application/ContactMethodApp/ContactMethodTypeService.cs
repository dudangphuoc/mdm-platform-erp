using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Models;

namespace Identity.Application.ContactMethodApp;

public class ContactMethodTypeService : AsyncCrudAppService<PartyContactType, ContactMethodTypeModel, Guid, GetAllContactMethodTypeModel, CreateContactMethodTypeModel, UpdateContactMethodTypeModel, GetContactMethodTypeModel, DeleteContactMethodTypeModel>, IContactMethodTypeService
{
    public ContactMethodTypeService(IRepository<PartyContactType, Guid> repository) : base(repository)
    {
    }

    protected override IQueryable<PartyContactType> CreateFilteredQuery(GetAllContactMethodTypeModel input)
    {
        var query = base.CreateFilteredQuery(input)
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name));

        return query;
    }

    public override async Task<ContactMethodTypeModel> GetAsync(GetContactMethodTypeModel input)
    {
        var partyContactType = await Repository.FirstOrDefaultAsync(input.Id);
        if (partyContactType == null)
            throw new UserFriendlyException("ERR_CONTACTMETHODTYPE_NOT_FOUND");

        return ObjectMapper.Map<ContactMethodTypeModel>(partyContactType);
    }
}