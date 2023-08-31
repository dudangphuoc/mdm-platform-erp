using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerType))]
public class CreateCustomerTypeModel
{

    /// <summary>
    /// Tên loại khách hàng
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mã loại khách hàng
    /// </summary>
    public Guid? CustomerTypeGroupId { get; set; }

    /// <summary>
    /// Mô tả loại khách hàng
    /// </summary>
    public string? Desc { get; set; }
}
