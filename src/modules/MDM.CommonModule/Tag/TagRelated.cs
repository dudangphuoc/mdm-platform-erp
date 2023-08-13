using Abp.Domain.Entities;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CommonModule.Tag;

[InjectContext]
[Table(nameof(TagRelated))]
public class TagRelated : Entity<Guid>
{
    public Guid TagId { get; set; }

    public string EntityName { get; set; }

    public Guid EntityId { get; set; }

    [ForeignKey(nameof(TagId))]
    public MDMTag Tag { get; set; }
}