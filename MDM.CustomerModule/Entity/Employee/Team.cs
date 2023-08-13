using MDM.Common.EntityFactory;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Employee;

[InjectContext]
[Table("Team")]
public class Team : MDMFullAuditedEntityBase
{
    public Guid? ParentId { get; set; }

    public Guid? BranchId { get; set; }

    public Branch Branch { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Code { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string TeamType { get; set; }

    public bool IsActive { get; set; }

    public bool IsChannel { get; set; }

    public ICollection<Team>? Teams { get; set; }
}