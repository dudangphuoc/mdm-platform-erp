using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegment))]
public class UpdateCustomerSegmentModel : CreateCustomerSegmentModel, IEntityDto<Guid>
{
    /// <summary>
    /// Id cụm khách hàng.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Id loại cụm khách hàng.
    /// </summary>
    public Guid CustomerSegmentTypeId { get; set; }
}

