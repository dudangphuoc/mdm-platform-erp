using MDM.ModuleBase;

namespace MDM.CustomerModule.Models;

public class CreatePersonModel
{
    public string Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public EGender? Gender { get; set; }
}


