using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[Table("PartyIdentificationTypes")]
public class PartyIdentificationType : MDMFullAuditedEntityBase
{
    public static string nameOfIDCard = "IDCard";
    public static string nameOfTelePhoneNumber = "TelePhoneNumber";
    public static string nameOfTaxCode = "TaxCode";
    
    public Guid PartyIdentificationId { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    [ForeignKey(nameof(PartyIdentificationId))]
    public PartyIdentification PartyIdentification { get; set; }
}