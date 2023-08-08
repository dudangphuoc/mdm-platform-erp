using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Product;

[Table(nameof(ComboProductItem))]
public class ComboProductItem : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }

    public Guid CategoryId { get; set; }

    public Guid? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public ComboProductItem? Parent { get; set; }

    public ICollection<ComboItem> ComboItems { get; set; }
}
