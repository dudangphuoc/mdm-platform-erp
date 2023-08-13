using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EProductType
{
    [Display(Name = "Simple")]
    Simple = 1,

    [Display(Name = "Gift")]
    Gift = 2
}