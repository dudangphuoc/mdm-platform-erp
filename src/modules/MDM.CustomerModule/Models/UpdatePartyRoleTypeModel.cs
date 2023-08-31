using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyAssignment;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyRoleType))]
public class UpdatePartyRoleTypeModel : CreatePartyRoleTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
