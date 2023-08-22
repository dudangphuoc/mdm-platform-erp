using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class DeletePartyTypeModel : IEntityDto<Guid>
{
    /// <summary>
    /// Id loại party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}