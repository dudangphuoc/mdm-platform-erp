using Abp.Application.Services.Dto;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;

public class GetPartyAffiliationTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
