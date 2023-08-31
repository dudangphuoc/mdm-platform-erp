using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetEmployeeTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

