using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyAssignment;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyRoleType))]
public class CreatePartyRoleTypeModel
{
    /// <summary>
    /// Tên loại vai trò
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mô tả vai trò
    /// </summary>
    public string? Desc { get; set; }
}
