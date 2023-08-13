using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Employee;

[InjectContext]
[Table(nameof(EmployeeType))]
public class EmployeeType : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string Desc { get; set; }
}