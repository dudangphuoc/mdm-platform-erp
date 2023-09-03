using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;
public class GetPartyModel : IEntityDto<Guid>
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}