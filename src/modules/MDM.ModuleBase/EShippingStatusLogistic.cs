using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MDM.ModuleBase
{
    public enum EShippingStatusLogistic
    {
        [Display(Name = "Mới")]
        New = 1,

        [Display(Name = "Đã điều phối")]
        Redistributed = 2,

        [Display(Name = "Đang thực hiện")]
        Delivery = 3,

        [Display(Name = "Đã hoàn thành")]
        Delivered = 4,

        [Display(Name = "Đã xác nhận")]
        Confirm = 5,

        [Display(Name = "Đã hẹn lại")]
        Appointment = 6,

        [Display(Name = "Đã hủy")]
        Canceled = 7,

        [Display(Name = "Từ chối thực hiện")]
        Reject = 8,

        [Display(Name = "TNBH đã xác nhận")]
        TNBHConfirm = 9,
    }
}
