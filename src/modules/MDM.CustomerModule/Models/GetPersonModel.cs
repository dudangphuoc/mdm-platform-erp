using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetPersonModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
