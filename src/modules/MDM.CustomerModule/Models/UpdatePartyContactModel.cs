using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;
[AutoMap(typeof(PartyContactMethod))]
public class UpdatePartyContactModel : CreatePartyContactModel, IEntityDto<Guid>
{
    /// <summary>
    /// Id phương thức liên lạc của party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}