using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllCustomerSegmentModel : PagedAndSortedResultRequestDto
{
    public Guid? CustomerSegmentTypeId { get; set; }
}

