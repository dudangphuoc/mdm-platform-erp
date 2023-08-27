using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.DynamicCustomer;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Employee
{
    [InjectContext]
    [Table("Branches")]
    public class Branch : MDMFullAuditedEntityBase
    {
        public Guid? PartyId { get; set; }

        public Guid? PartyRoleAssignmentId { get; set; }

        public bool AnonymousFlag { get; set; }
 
        [ForeignKey(nameof(PartyId))]
        public PartiesBase Party { get; set; }

        [ForeignKey(nameof(PartyRoleAssignmentId))]
        public PartyRoleAssignment PartyRoleAssignment { get; set; }

        public ICollection<CustomerAttributeValue> CustomerDynamicAtrributeValues { get; set; }
    }
}