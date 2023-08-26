using Abp.Domain.Entities.Auditing;
using MDM.Common;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyModel;

[InjectContext]
[Table(nameof(PartyType))]
public class PartyType : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string NormalizedName { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Desc { get; set; }

    public virtual void SetNormalizedNames()
    {
        NormalizedName = Name.ToNoneSignVietnameseNormalized();
    }
}