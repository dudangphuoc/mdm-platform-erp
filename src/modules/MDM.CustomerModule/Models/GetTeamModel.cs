using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetTeamModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
