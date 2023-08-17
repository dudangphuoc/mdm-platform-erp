using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum ERelatedType
{
    [Display(Name = "Primary")]
    Simple = 1000,

    [Display(Name = "Variant")]
    Bundle = 2000,

    [Display(Name = "Recommance")]
    Recommance = 3000
}
