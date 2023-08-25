using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Castle.Core.Logging;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.PartyManager;

public interface IPartyStoreBase
{

}

public class NullPartyStoreBase : IPartyStoreBase
{

}

public class PartyStoreBase : IPartyStoreBase
{
    private readonly IRepository<PartiesBase, Guid> _partyRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    public ILogger Logger { get; set; }
    public PartyStoreBase(IRepository<PartiesBase, Guid> partyRepository, IUnitOfWorkManager unitOfWorkManager)
    {
        _partyRepository = partyRepository;
        _unitOfWorkManager = unitOfWorkManager;
        Logger = NullLogger.Instance;
    }

    public List<PartyTypeModel> PartyTypes { get; set; }
    public static List<PartyRoleTypeModel> PartyRoleTypes { get; set; }

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
