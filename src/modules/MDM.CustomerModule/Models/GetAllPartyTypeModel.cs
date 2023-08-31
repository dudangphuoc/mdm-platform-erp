using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllPartyTypeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên loại party (thực thể/ đối tượng).
    /// </summary>
    public string? Name { get; set; }
}