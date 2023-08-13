using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("Addresses")]
public class Address : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(500)")]
    public string AddressLine { get; set; }

    public Guid? CountryId { get; set; }

    public Guid? ProvinceId { get; set; }

    public Guid? DistrictId { get; set; }

    public Guid? WardId { get; set; }

    public ICollection<PartyContactMethod> PartyContactMethods { get; set; }
}