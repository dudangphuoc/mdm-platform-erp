using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetPartyAffiliationModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
