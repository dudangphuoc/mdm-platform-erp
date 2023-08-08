using Castle.MicroKernel.SubSystems.Conversion;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Product
{
    [Table(nameof(ProductUnit))]
    public class ProductUnit : MDMFullAuditedEntityBase
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
    }
}