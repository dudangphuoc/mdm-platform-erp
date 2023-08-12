using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

public class ExtensionGroup : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "varchar(128)")]
    public required string Name { get; set; }
}
