using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("PartyIdentification")]
public class PartyIdentification : MDMFullAuditedEntityBase
{
    public Guid PartyId { get; set; }

    public Guid? TelePhoneId { get; set; }

    public Guid? AddressId { get; set; }

    public Guid? EmailId { get; set; }

    public Guid PartyIdentificationTypeId { get; set; }

    [Column(TypeName = "varchar(15)")]
    public string? IDCard { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? TaxCode { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(TelePhoneId))]
    public TelePhone TelePhone { get; set; }

    [ForeignKey(nameof(EmailId))]
    public Email Email { get; set; }

    [ForeignKey(nameof(AddressId))]
    public Address Address { get; set; }

    [ForeignKey(nameof(PartyIdentificationTypeId))]
    public PartyIdentificationType PartyIdentificationType { get; set; }
}
