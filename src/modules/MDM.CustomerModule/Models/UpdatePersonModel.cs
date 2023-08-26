using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class UpdatePersonModel : CreatePersonModel, IEntityDto<Guid>
{
    public Guid Id { get; set ; }
}
