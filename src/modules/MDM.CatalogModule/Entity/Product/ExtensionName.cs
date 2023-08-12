using Abp.Domain.Entities.Auditing;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[Table(nameof(ExtensionName))]
public class ExtensionName : CreationAuditedEntity<Guid>
{
    public Guid GroupId { get; set; }

    [Column(TypeName = "varchar(128)")]
    public required string Name { get; set; }

    [ForeignKey(nameof(GroupId))]
    public ExtensionGroup Group { get; set; }

    public ICollection<ExtensionValue> Values { get; set; }
}
