using System.ComponentModel.DataAnnotations;

namespace MDM.ModuleBase
{
    public enum EOrderStatus
    {
        //[Display(Name = "New")]
        [Display(Name = "Mới")]
        New = 10,

        //[Display(Name = "Pending")]
        [Display(Name = "Chờ xử lý")]
        Pending = 30,

        //[Display(Name = "Processing")]
        [Display(Name = "Đang xử lý")]
        Processing = 40,

        //[Display(Name = "Cancelled")]
        [Display(Name = "Hủy")]
        Canceled = 50,

        //[Display(Name = "Completed")]
        [Display(Name = "Hoàn thành")]
        Complete = 60,

        //[Display(Name = "Closed")]
        [Display(Name = "Đóng")]
        Closed = 70,

        //[Display(Name = "Splited")]
        [Display(Name = "Đã tách đơn")]
        Splited = 80
    }
}
