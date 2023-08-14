using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.ModuleBase;

public interface IMustHaveOrderStatus
{
    EPaymentStatus PaymentStatus { get; set; }

    EOrderStatus OrderStatus { get; set; }
}
