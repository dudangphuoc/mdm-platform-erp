using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;


[AutoMap(typeof(CustomerSegmentType))]
public class UpdateCustomerSegmentTypeModel : CreateCustomerSegmentTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

