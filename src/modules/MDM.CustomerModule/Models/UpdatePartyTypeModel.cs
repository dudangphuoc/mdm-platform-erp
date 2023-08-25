using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;
[AutoMap(typeof(PartyType))]
public class UpdatePartyTypeModel : CreatePartyTypeModel, IEntityDto<Guid>
{
    /// <summary>
    /// Id loại party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}
