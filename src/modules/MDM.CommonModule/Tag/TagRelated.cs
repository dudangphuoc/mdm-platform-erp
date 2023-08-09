using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CommonModule.Tag;

public class TagRelated : Entity<Guid>
{
    public Guid TagId { get; set; }

    public Type EntityType { get; set; }

    public Guid EntityId { get; set; }

    [ForeignKey(nameof(TagId))]
    public MDMTag Tag { get; set; }
}
