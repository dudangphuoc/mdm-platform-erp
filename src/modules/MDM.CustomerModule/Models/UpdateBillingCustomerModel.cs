using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(BillingCustomer))]
public class UpdateBillingCustomerModel : CreateBillingCustomerModel, IEntityDto<Guid>
{
    /// <summary>
    /// Id thông tin hóa đơn của KH (đại lý).
    /// </summary>
    public Guid Id { get; set; }
}
