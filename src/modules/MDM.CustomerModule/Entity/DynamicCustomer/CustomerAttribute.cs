using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.DynamicCustomer
{
    [InjectContext]
    public class CustomerAttribute : CreationAuditedEntity<Guid>
    {
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string DisplayName { get; set; }

        public required EDataType DataType { get; set; }

        public ICollection<CustomerAttributeValue>? CustomerAtrributeValues { get; set; }
    }
}

