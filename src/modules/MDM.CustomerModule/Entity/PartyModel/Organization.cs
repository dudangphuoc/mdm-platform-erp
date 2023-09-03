using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.PartyModel;

[Table("Organizations")]
public class Organization : PartiesBase
{
    [Column(TypeName = "nvarchar(500)")]
    public string OrganizationName { get; set; }
}
