using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.Person;

[InjectContext]
[Table("Persons")]
public class PersonBase : PartiesBase
{
    public static string Key = "Person";

    [Column(TypeName = "nvarchar(500)")]
    public string Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public EGender? Gender { get; set; }

}