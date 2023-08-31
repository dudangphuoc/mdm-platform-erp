using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(Team))]
public class UpdateTeamModel : CreateTeamModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
