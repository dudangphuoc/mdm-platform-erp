using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllEmployeeTypeModel : PagedAndSortedResultRequestDto
{

    /// <summary>
    /// Tên loại nhân viên
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mô tả loại nhân viên
    /// </summary>
    public string Desc { get; set; }
}

