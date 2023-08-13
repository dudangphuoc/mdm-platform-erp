using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase;

public enum EPaymentStatus
{
    //[Display(Name = "Waiting Payment")]
    [Display(Name = "Chờ thanh toán")]
    Waiting = 1,

    //[Display(Name = "Payment Success")]
    [Display(Name = "Thanh toán thành công")]
    Success = 10,

    //[Display(Name = "Payment Failed")]
    [Display(Name = "Thanh toán thất bại")]
    Failure = 20,

    //[Display(Name = "Cancel Payment")]
    [Display(Name = "Hủy thanh toán")]
    Cancel = 30,

    //[Display(Name = "Payment Expried")]
    [Display(Name = "Hết hạn thanh toán")]
    Expried = 40
}
