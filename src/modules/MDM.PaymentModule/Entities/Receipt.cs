using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.PaymentModule.Entities;

public class Receipt : MDMFullAuditedEntityBase
{
    /// <summary>
    /// Số tiền đã nhận.
    /// </summary>
    [DataType("decimal(18,2)")]
    public decimal TotalReceived { get; set; }

    /// <summary>
    /// Số tiền cấn trừ.
    /// </summary>
    [DataType("decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Số tiền còn dư ra sau khi cấn trừ.
    /// </summary>
    [DataType("decimal(18,2)")]
    public decimal RemainingAmount { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string Note { get; set; }
}
