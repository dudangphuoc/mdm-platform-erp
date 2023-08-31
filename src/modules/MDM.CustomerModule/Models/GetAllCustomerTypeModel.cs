using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllCustomerTypeModel : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }
    public Guid[] CustomerTypeGroupIds { get; set; }
}
