using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerType))]
public class UpdateCustomerTypeModel : CreateCustomerTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
