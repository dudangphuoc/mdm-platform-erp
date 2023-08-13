using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyAssignment;

[InjectContext]
[Table("PartyRoleAssignments")]
public class PartyRoleAssignment : MDMFullAuditedEntityBase
{
    public Guid PartyId { get; set; }

    public Guid PartyRoleTypeId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    //CustomerBase | EmployeeBase | Supplier | Branch
    public string[] Source { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(PartyRoleTypeId))]
    public PartyRoleType PartyRoleType { get; set; }

    public ICollection<PartyContactMethod> PartyContactMethods { get; set; }

    /// <summary>
    /// Get source of PartyRoleAssignment
    /// </summary>
    /// <returns>IQueryable</returns>
    public virtual IQueryable GetSource()
    {
        return null;
    }
}