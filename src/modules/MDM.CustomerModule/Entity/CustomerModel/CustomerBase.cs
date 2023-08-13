using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("Customers")]
public class CustomerBase : MDMFullAuditedEntityBase
{
    public override Guid Id { get => base.Id; set => base.Id = value; }
 
    public Guid PartyId { get; set; }
    
    public Guid PartyRoleAssignmentId { get; set; }

    public Guid CustomerTypeId { get; set; }

    public bool AnonymousFlag { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string CustomerCode { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(PartyRoleAssignmentId))]
    public PartyRoleAssignment PartyRoleAssignment { get; set; }

    [ForeignKey(nameof(CustomerTypeId))]
    public CustomerType CustomerType { get; set; }

    public ICollection<CustomerSegment> CustomerSegments { get; set; }

    public ICollection<BillingCustomer> BillingCustomers { get; set; }
}