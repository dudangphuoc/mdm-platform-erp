using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetCustomerTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
