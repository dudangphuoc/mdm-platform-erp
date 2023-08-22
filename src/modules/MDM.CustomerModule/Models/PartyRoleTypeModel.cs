using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyAssignment;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyRoleType))]
public class PartyRoleTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại role.
    /// </summary>
    public string Name { get; set; }

    public string? Desc { get; set; }
}