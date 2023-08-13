using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Employee;

[InjectContext]
[Table("TeamHistory")]
public class TeamHistory : CreationAuditedEntity<Guid>
{
    public Guid EmployeeId { get; set; }

    public Guid TeamId { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string TeamName { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public EmployeeBase Employee { get; set; }

    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; }
}
