using MDM.CustomerModule.Entity.PartyAssignment;

namespace MDM.CustomerModule.PartyManager;

public interface IPartyRoleAssignmentStoreBase
{
    Task<IEnumerable<PartyRoleAssignmentMapper>> GetByPartyAndMapingAsync(Guid partyId, string source);
    Task<IEnumerable<PartyRoleAssignmentMapper>> GetByPartyAndMapingAsync(Guid partyId, string[] sources);
    Task<IEnumerable<PartyRoleAssignmentMapper>> GetByPartyAsync(Guid partyId, string source);
}
