using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllCustomerModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên khách hàng/ đại lý.
    /// </summary>
    public string? Name { get; set; }

    public override int MaxResultCount
    {
        get => base.MaxResultCount;
        set
        {
            base.MaxResultCount = value <= 100 ? value : 100;
        }
    }

    public bool? IsActive { get; set; }

    public string? AgentLevel { get; set; }

    public string? DTCode { get; set; }
}