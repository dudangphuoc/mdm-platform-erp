using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetCustomerSegmentTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

