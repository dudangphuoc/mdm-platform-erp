using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table(nameof(ProductVariant))]
public class ProductVariant : MDMFullAuditedEntityBase, IMayHavePrimary
{
    [Column(TypeName = "nvarchar(64)")]
    public string Code { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(128)")]
    public string Barcode { get; set; }

    public int DisplayOrder { get; set; }

    public Guid ProductId { get; set; }

    public bool IsPrimary { get; set; }

    [ForeignKey(nameof(ProductId))]
    public ProductBase Product { get; set; }
}
