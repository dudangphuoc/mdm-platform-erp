using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Price
{
    [InjectContext]
    [Table("PriceLists")]
    public class PriceList : MDMFullAuditedEntityBase
    {
        public Guid CurrencyId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? Description { get; set; }

        public int Priority { get; set; }

        public bool IsActive { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<Price>? Prices { get; set; }

        public ICollection<PriceListAssignment>? PriceListAssignments { get; set; }
    }
}