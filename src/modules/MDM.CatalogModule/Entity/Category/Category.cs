using Abp.Domain.Entities;
using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Category;

[InjectContext]
[Table("Category")]
public class Category : MDMFullAuditedEntityBase, IPassivable
{
    public virtual Guid ParentId { get; set; }

    public virtual int Level { get; set; }

    public virtual bool IncludeInTopMenu { get; set; }

    public bool IsActive { get; set; }

    public virtual int DisplayOrder { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string Name { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public virtual string Description { get; set; }


    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoTitle { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoKeywords { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoDescription { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoSlug { get; set; }

    public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

    public virtual ICollection<Category> ParentCategories { get; set; } = new List<Category>();

    public virtual ICollection<Category> AllParentCategories { get; set; } = new List<Category>();

    public virtual ICollection<Category> AllSubCategories { get; set; } = new List<Category>();

    public virtual ICollection<Category> AllCategories { get; set; } = new List<Category>();
}
