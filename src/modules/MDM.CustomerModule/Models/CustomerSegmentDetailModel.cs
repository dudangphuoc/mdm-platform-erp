using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegment))]
public class CustomerSegmentDetailModel : EntityDto<Guid>
{
    /// <summary>
    /// Id loại cụm khách hàng.
    /// </summary>
    public Guid CustomerSegmentTypeId { get; set; }

    /// <summary>
    /// Tên loại cụm khách hàng.
    /// </summary>
    public string CustomerSegmentTypeName { get; set; }

    /// <summary>
    /// Thứ tự.
    /// </summary>
    public int? CustomerSegmentTypePriority { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}
