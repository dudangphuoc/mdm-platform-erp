using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyContact;

namespace Identity.Application.PartyIdentificationTypeApp;

public class DeletePartyIdentificationTypeModel : EntityDto<Guid>
{
}

public class GetPartyIdentificationTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class UpdatePartyIdentificationTypeModel : CreatePartyIdentificationTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class CreatePartyIdentificationTypeModel
{
    public Guid PartyId { get; set; }
    `
    public Guid PartyContactTypeId { get; set; }

    public string? IDCard { get; set; }

    public string? TaxCode { get; set; }
}

public class GetAllPartyIdentificationTypeModel : PagedAndSortedResultRequestDto
{
    public Guid? PartyId { get; set; }
    public Guid? PartyContactTypeId { get; set; }
    public string? IDCard { get; set; }
    public string? TaxCode { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class PartyIdentificationTypeModel : EntityDto<Guid>
{
    public Guid PartyId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    public string? IDCard { get; set; }


    public string? TaxCode { get; set; }
}


public interface IPartyIdentificationTypeService : IAsyncCrudAppService<PartyIdentificationTypeModel, Guid, GetAllPartyIdentificationTypeModel, CreatePartyIdentificationTypeModel, UpdatePartyIdentificationTypeModel, GetPartyIdentificationTypeModel, DeletePartyIdentificationTypeModel>
{

}

public class PartyIdentificationTypeService : AsyncCrudAppService<PartyIdentification, PartyIdentificationTypeModel, Guid, GetAllPartyIdentificationTypeModel, CreatePartyIdentificationTypeModel, UpdatePartyIdentificationTypeModel, GetPartyIdentificationTypeModel, DeletePartyIdentificationTypeModel>, IPartyIdentificationTypeService
{
    public PartyIdentificationTypeService(IRepository<PartyIdentification, Guid> repository) : base(repository)
    {

    }
}

