using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegment))]
public class CustomerSegmentModel : EntityDto<Guid>
{
    /// <summary>
    /// Id khách hàng.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid? PartyId { get; set; }

    /// <summary>
    /// Tên khách hàng.
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// Id loại cụm khách hàng.
    /// </summary>
    public Guid CustomerSegmentTypeId { get; set; }

    /// <summary>
    /// Tên loại cụm khách hàng.
    /// </summary>
    public string CustomerSegmentTypeName { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}

