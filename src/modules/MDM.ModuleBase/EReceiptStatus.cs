using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EReceiptStatus
{
    //[Display(Name = "New")]
    [Display(Name = "Mới")]
    New = 1,

    //[Display(Name = "Complete")]
    [Display(Name = "Hoàn thành")]
    Complete = 10,

    //[Display(Name = "Cancel")]
    [Display(Name = "Hủy")]
    Cancel = 20
}
