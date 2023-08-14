using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductBundles")]
public class ProductBundle : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; }

    public required EProductBundleType ProductBundleType { get; set; } 

    public Guid? ProductRelated { get; set; }

    public required ICollection<ProductBundleColection> BundleColection { get; set; }
}
