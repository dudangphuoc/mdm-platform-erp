using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegmentType))]
public class CustomerSegmentTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại cụm khách hàng.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Ngày cập nhật.
    /// </summary>
    public DateTime? LastModificationTime { get; set; }
}

