using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllPersonModel : PagedAndSortedResultRequestDto
{
    public string Name { get; set; }
}
