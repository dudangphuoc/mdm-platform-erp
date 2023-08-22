using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyType))]
public class PartyTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại party (thực thể/ đối tượng).
    /// </summary>
    public string Name { get; set; }
}
