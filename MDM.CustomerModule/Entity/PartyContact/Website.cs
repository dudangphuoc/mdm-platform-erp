using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyContact;

[InjectContext]
[Table("Websites")]
public class Website : CreationAuditedEntity<Guid>
{
    [Column(TypeName = "nvarchar(500)")]
    public string HomePageUrlName { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string BussinessName { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string TitleTag { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string MetaDescription { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string MetaKeywrod { get; set; }
}