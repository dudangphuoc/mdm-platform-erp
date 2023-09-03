using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerSegmentType))]
public class CreateCustomerSegmentTypeModel
{
    /// <summary>
    /// Tên loại cụm khách hàng.
    /// </summary>
    public string Name { get; set; }
}

