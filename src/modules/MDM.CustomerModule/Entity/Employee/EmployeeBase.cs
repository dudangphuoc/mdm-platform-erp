using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.DynamicCustomer;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Employee;

[InjectContext]
[Table("Employee")]
public class EmployeeBase : MDMFullAuditedEntityBase
{
    public override Guid Id { get => base.Id; set => base.Id = value; }

    public Guid PartyId { get; set; }

    public Guid? TeamId { get; set; }

    [ForeignKey(nameof(PartyRoleAssignmentId))]
    public Guid? PartyRoleAssignmentId { get; set; }

    public Guid EmployeeTypeId { get; set; }

    [ForeignKey(nameof(EmployeeTypeId))]
    public EmployeeType EmployeeType { get; set; }

    public PartyRoleAssignment PartyRoleAssignment { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; }

    public ICollection<CustomerAtrributeValue> CustomerDynamicAtrributeValues { get; set; }
}