using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EInvoiceStatus
{
    //[Display(Name = "New")]
    [Display(Name = "Mới")]
    New = 1,

    //[Display(Name = "Complete")]
    [Display(Name = "Hoàn thành")]
    Complete = 10,

    //[Display(Name = "Complete")]
    [Display(Name = "Chưa hoàn thành")]
    Incomplete = 20,

    //[Display(Name = "Cancel")]
    [Display(Name = "Hủy")]
    Cancel = 30
}
