using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EAddressType
{
    [Display(Name = "Nhà riêng")]
    Home = 1,

    [Display(Name = "Cơ quan")]
    Office = 2
}
