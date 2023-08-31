using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetBillingCustomerModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
