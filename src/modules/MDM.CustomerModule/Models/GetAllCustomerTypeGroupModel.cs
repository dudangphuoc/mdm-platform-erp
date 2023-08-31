using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllCustomerTypeGroupModel : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }
}

