using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table(nameof(PartyContactMethod))]
public class PartyContactMethod : MDMFullAuditedEntityBase
{
    public Guid PartyRoleAssignmentId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string ContactName { get; set; }

    public bool IsDefault { get; set; }

    public EAddressType? AddressType { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public PartyRoleAssignment PartyRoleAssignment { get; set; }

    public PartyContactType ContactMethodType { get; set; }

    public ICollection<Email> Emails { get; set; }

    public ICollection<Address> Addresses { get; set; }

    public ICollection<TelePhone> TelePhones { get; set; }

    public ICollection<Website> Websites { get; set; }
}
