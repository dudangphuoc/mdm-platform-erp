using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MDM.ModuleBase
{
    public enum EShippingStatus
    {
        [Display(Name = "Mới")]
        New = 10,

        [Display(Name = "Đã điều phối")]
        Redistribution = 20,

        [Display(Name = "Đang giao")]
        Delivery = 30,

        [Display(Name = "Giao hàng thành công")]
        Delivered = 40,

        [Display(Name = "Giao hàng thất bại")]
        Failure = 50,

        [Display(Name = "Đã huỷ")]
        Canceled = 60,
    }
}
