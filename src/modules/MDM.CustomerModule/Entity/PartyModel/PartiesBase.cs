using Abp.Domain.Entities;
using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.Person;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyModel;

[InjectContext]
[Table("Parties")]
public class PartiesBase : MDMFullAuditedEntityBase, IPassivable
{
    public Guid PartyTypeId { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? FullName { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? Remark { get; set; }

    public bool IsActive { get; set; }

    public CustomerBase Customer { get; set; }

    public EmployeeBase Employee { get; set; }

    public Branch Branch { get; set; }

    public PartyType PartyType { get; set; }

    public Supplier Supplier { get; set; }

    public PersonBase Person { get; set; }

    public PartyIdentification? PartyIdentification { get; set; }

    public ICollection<PartyAffiliation> PartyAffiliations { get; set; }

    public ICollection<PartyAffiliation> SubPartyAffiliations { get; set; }

    public ICollection<PartyRoleAssignment> PartyRoleAssignments { get; set; }
}
