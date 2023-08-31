using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;


public class GetAllPartyAffiliationTypeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên loại đối tượng
    /// </summary>
    public string Name { get; set; }
}
