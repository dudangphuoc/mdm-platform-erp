using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using MDM.CustomerModule.Entity.PartyModel;
using Z.EntityFramework.Plus;

namespace MDM.CustomerModule.EntityTypeService;

internal class PartyTypeModel : IPartyTypeModel, ISingletonDependency
{
    private IEnumerable<PartyType> partyTypes;

    public IEnumerable<PartyType> PartyTypes { get => partyTypes; private set => partyTypes = value; }

    public PartyTypeModel(IRepository<PartyType, Guid> repository)
    {
        PartyTypes = repository.GetAll().FromCache();
        if (PartyTypes.Count() == 0)
        {
            throw new UserFriendlyException("ERR_PARTYTYPE_NOT_FOUND");
        }
    }

    public Guid Person
    {
        get
        {
            var value = PartyTypes?.FirstOrDefault(p => p.Name.Equals(nameof(Person)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid Organization
    {
        get
        {
            var value = PartyTypes.FirstOrDefault(p => p.Name.Equals(nameof(Organization)));
            return value == null ? new Guid() : value.Id;
        }
    }

}
