using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetPartyIdentificationTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

