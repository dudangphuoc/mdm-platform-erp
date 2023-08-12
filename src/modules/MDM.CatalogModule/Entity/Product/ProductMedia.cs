using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Product
{
    [Table(nameof(ProductMedia))]
    public class ProductMedia : MDMFullAuditedEntityBase
    {
        public Guid ProductId { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Url { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string? Title { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? Description { get; set; }

        public EMediaType MediaType { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductBase Product { get; set; }
    }
}
