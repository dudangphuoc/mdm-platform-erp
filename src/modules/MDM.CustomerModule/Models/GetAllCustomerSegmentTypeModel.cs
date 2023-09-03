using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllCustomerSegmentTypeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên loại cụm khách hàng.
    /// </summary>
    public string? Name { get; set; }
}

