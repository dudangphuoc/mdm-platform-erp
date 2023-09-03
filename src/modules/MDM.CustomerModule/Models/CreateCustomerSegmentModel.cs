using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegment))]
public class CreateCustomerSegmentModel
{
    /// <summary>
    /// Id loại cụm khách hàng.
    /// </summary>
    public Guid CustomerSegmentTypeId { get; set; }

    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }
}

