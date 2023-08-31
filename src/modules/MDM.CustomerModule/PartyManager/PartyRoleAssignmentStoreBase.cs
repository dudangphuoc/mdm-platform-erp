using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Timing;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyAssignment;
using Microsoft.Extensions.Caching.Memory;
using Z.EntityFramework.Plus;

namespace MDM.CustomerModule.PartyManager;

public class PartyRoleAssignmentStoreBase : IPartyRoleAssignmentStoreBase, ITransientDependency
{
    private readonly IRepository<PartyRoleAssignment, Guid> _partyRoleAssignmentRepository;

    private MemoryCacheEntryOptions _memoryCacheEntryOptions
    {
        get
        {
            var option =  new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = Clock.Now.AddMinutes(1),
            };
            return option;
        }
    }

    public PartyRoleAssignmentStoreBase(IRepository<PartyRoleAssignment, Guid> partyRoleAssignmentRepository)
    {
        _partyRoleAssignmentRepository = partyRoleAssignmentRepository;
    }

    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Task<IEnumerable<PartyRoleAssignmentMapper>> GetByPartyAsync(Guid partyId, string source)
    {
        var partyRoleAssign = _partyRoleAssignmentRepository.GetAll()
                .Where(x => x.Source.Contains(source) &&
                    (x.ExpirationDate == null || x.ExpirationDate > Clock.Now)).Select(x => x.MapTo<PartyRoleAssignmentMapper>())
                .FromCache(_memoryCacheEntryOptions, nameof(PartyRoleAssignment), source, partyId.ToString().Normalize());

        return Task.FromResult(partyRoleAssign);
    }

    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Task<IEnumerable<PartyRoleAssignmentMapper>> GetByPartyAndMapingAsync(Guid partyId, string source)
    {
        var partyRoleAssign = _partyRoleAssignmentRepository.GetAll()
                .Where(x => x.Source.Contains(source) &&
                    (x.ExpirationDate == null || x.ExpirationDate > Clock.Now)).Select(x => x.MapTo<PartyRoleAssignmentMapper>())
                .FromCache(_memoryCacheEntryOptions, nameof(PartyRoleAssignment), source, partyId.ToString().Normalize());

        foreach (var item in partyRoleAssign)
        {
            if (item.Source == nameof(CustomerBase))
            {
                item.GetSourceData<CustomerBase, Guid>(item.SourceId);
            }

            if (item.Source == nameof(EmployeeBase))
            {
                item.GetSourceData<EmployeeBase, Guid>(item.SourceId);
            }

            if (item.Source == nameof(Supplier))
            {
                item.GetSourceData<Supplier, Guid>(item.SourceId);
            }

            if (item.Source == nameof(Branch))
            {
                item.GetSourceData<Branch, Guid>(item.SourceId);
            }

        }


        return Task.FromResult(partyRoleAssign);
    }
}
