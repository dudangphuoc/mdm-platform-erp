using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyModel;

[InjectContext]
[Table("PartyAffiliations")]
public class PartyAffiliation : MDMFullAuditedEntityBase
{
    public Guid PartyId { get; set; }

    public Guid SubPartyId { get; set; }

    public Guid PartyAffiliationTypeId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [ForeignKey(nameof(SubPartyId))]
    public PartiesBase SubParty { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    public PartyAffiliationType PartyAffiliationType { get; set; }
}