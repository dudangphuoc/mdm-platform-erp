using Abp.Domain.Entities;
using MDM.ModuleBase;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Product
{
    [Table("Brands")]
    public class Brand : MDMFullAuditedEntityBase, IPassivable
    {
        [Column(TypeName = "nvarchar(500)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Slug { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? Description { get; set; }

        [Description("brand is active")]
        public bool IsActive { get; set; }
    }
}
