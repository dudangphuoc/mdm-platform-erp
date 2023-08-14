using System.ComponentModel;

namespace MDM.ModuleBase;

public interface IMustHaveApproveDate : IMustHaveOrderStatus
{
    DateTime? ApproveDate { get; set; }

    [DefaultValue(false)]
    bool IsApproved { get; set; }
}
