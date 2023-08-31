using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetContactMethodTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
