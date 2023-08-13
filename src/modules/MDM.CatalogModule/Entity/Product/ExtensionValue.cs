using Abp.Domain.Entities;
using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table(nameof(ExtensionValue))]
public class ExtensionValue : MDMFullAuditedEntityBase, IPassivable
{
    public required Guid ExtensionNameId { get; set; }

    public string EntityName { get; set; }

    public Guid EntityId { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "varchar(512)")]
    public required string Value { get; set; }

    [ForeignKey(nameof(ExtensionNameId))]
    public ExtensionName ExtensionName { get; set; }
}
