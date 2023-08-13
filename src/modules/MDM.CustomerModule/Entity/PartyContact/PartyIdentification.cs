using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("PartyIdentification")]
public class PartyIdentification : MDMFullAuditedEntityBase
{
    public Guid PartyId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    [Column(TypeName = "varchar(15)")]
    public string? IDCard { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? TaxCode { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(PartyContactTypeId))]
    public PartyContactType PartyContactType { get; set; }

}
