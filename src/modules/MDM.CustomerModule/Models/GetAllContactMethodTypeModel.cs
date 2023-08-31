using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllContactMethodTypeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên loại phương thức liên hệ
    /// </summary>
    public string Name { get; set; }
}
