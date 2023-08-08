using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EComputePrice
{
    [Display(Name = "Fixed")]
    Fixed = 1,

    [Display(Name = "Percent")]
    Percent = 2
}
