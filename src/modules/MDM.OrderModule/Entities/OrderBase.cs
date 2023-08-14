using Abp.Domain.Entities;
using MDM.ModuleBase;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.OrderModule.Entities;

[Table("Orders")]
public abstract class OrderBase<TParty, TPaymentMethod> : MDMFullAuditedEntityBase, IMustHaveApproveDate, IMustHaveCompletedDate
    where TParty : Entity<Guid>
    where TPaymentMethod : Entity<Guid>
{
    [Column(TypeName = "varchar(50)")]
    public string OrderCode { get; set; }

    public EPaymentStatus PaymentStatus { get; set; }

    public EOrderStatus OrderStatus { get; set; }

    public EShippingStatus? ShippingStatus { get; set; }

    [DefaultValue(null)]
    public DateTime? ApproveDate { get; set; }

    [DefaultValue(false)]
    public bool IsApproved { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// Số tiền thuế.
    /// </summary>
    [DataType("Decimal(18,2)")]
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Tổng số tiền phải thanh toán (đã trừ số tiền giảm giá và tính thuế).
    /// </summary>
    [DataType("Decimal(18,2)")]
    public decimal OrderTotal { get; set; }

    /// <summary>
    /// Số tiền giảm giá.
    /// </summary>
    [DataType("Decimal(18,2)")]
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Tổng số tiền tạm tính (chưa trừ số tiền giảm giá).
    /// </summary>
    [DataType("Decimal(18,2)")]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Tổng số tiền đã giảm giá.
    /// </summary>
    [DataType("Decimal(18,2)")]
    public decimal SubTotalWithDiscount { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string? OrderNote { get; set; }

    public Guid OrderTypeId { get; set; }

    [ForeignKey(nameof(OrderTypeId))]
    public OrderType OrderType { get; set; }

    public virtual TParty Party { get; set; }

    public virtual TPaymentMethod PaymentMethod { get; set; }
}
