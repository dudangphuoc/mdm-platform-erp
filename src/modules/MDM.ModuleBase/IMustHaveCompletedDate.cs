using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.ModuleBase;

public interface IMustHaveCompletedDate : IMustHaveOrderStatus
{
    DateTime? CompletedDate { get; set; }
}
