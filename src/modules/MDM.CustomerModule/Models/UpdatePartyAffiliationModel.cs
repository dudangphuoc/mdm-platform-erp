using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class UpdatePartyAffiliationModel : CreatePartyAffiliationModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
