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

    public Guid? PartyContactTypeId { get; set; }

    public Guid? EmailId { get; set; }

    public Guid? AddressId { get; set; }

    public Guid? TelephoneId { get; set; }

    public Guid? WebsiteId { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string ContactName { get; set; }

    public bool IsDefault { get; set; }

    public EAddressType? AddressType { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public PartyRoleAssignment PartyRoleAssignment { get; set; }

    public PartyContactType ContactMethodType { get; set; }

    [ForeignKey(nameof(EmailId))]
    public Email? Email { get; set; }

    [ForeignKey(nameof(AddressId))]
    public Address? Address { get; set; }

    [ForeignKey(nameof(TelephoneId))]
    public TelePhone? TelePhone { get; set; }

    [ForeignKey(nameof(WebsiteId))]
    public Website? Website { get; set; }
}
