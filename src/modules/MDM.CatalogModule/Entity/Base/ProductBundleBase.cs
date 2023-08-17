using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Base;


[Table("ProductBundles")]
public class ProductBundleBase<TBundleColection> : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(1000)")]
    public string Description { get; set; }

    public ICollection<TBundleColection>? BundleColections { get; set; }
}
