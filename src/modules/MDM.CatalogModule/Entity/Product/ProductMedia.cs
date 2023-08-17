using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product;

[InjectContext]
[Table("ProductMedias")]
public class ProductMedia : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(512)")]
    public string Url { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string? Title { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }

    public EMediaType MediaType { get; set; }
}
