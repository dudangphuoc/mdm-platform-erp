using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.EntityTypeService;

public interface IPartyTypeModel
{
    IEnumerable<PartyType> PartyTypes { get; }

    Guid Person { get; }

    Guid Organization { get; }
    
}
