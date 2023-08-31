using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyAssignment;

[InjectContext]
[Table("PartyRoleAssignments")]
public class PartyRoleAssignment : MDMFullAuditedEntityBase
{
    public Guid PartyId { get; set; }

    public Guid SourceId { get; set; }

    public Guid PartyRoleTypeId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    //CustomerBase | EmployeeBase | Supplier | Branch
    public string Source { get; set; }

    [ForeignKey(nameof(PartyId))]
    public PartiesBase Party { get; set; }

    [ForeignKey(nameof(PartyRoleTypeId))]
    public PartyRoleType PartyRoleType { get; set; }

    public ICollection<PartyContactMethod> PartyContactMethods { get; set; }
}

[AutoMap(typeof(PartyRoleAssignment))]
public class PartyRoleAssignmentMapper : PartyRoleAssignment
{
    public object? SourceData { get; set; }

    public void GetSourceData<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : Entity<TPrimaryKey>
    {
        using (var repo = IocManager.Instance.ResolveAsDisposable<IRepository<TEntity, TPrimaryKey>>())
        {
            SourceData = repo.Object.FirstOrDefault(id);
        }
    }
}