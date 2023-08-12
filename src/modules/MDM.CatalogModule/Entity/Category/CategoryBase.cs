using Abp.Domain.Entities;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Entity.Category;

public class CategoryBase : MDMFullAuditedEntityBase, IPassivable
{
    [Column(TypeName = "nvarchar(256)")]
    public virtual string Name { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public virtual string Description { get; set; }

    public virtual int DisplayOrder { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoTitle { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoKeywords { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoDescription { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual string SeoSlug { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public virtual Guid ParentId { get; set; }

    public virtual int Level { get; set; }

    public virtual bool IncludeInTopMenu { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CategoryBase> SubCategories { get; set; } = new List<CategoryBase>();

    public virtual ICollection<CategoryBase> ParentCategories { get; set; } = new List<CategoryBase>();

    public virtual ICollection<CategoryBase> AllParentCategories { get; set; } = new List<CategoryBase>();

    public virtual ICollection<CategoryBase> AllSubCategories { get; set; } = new List<CategoryBase>();

    public virtual ICollection<CategoryBase> AllCategories { get; set; } = new List<CategoryBase>();
}
