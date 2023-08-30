using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllPartyIdentificationTypeModel : PagedAndSortedResultRequestDto
{
    public Guid? PartyId { get; set; }
    public Guid? PartyContactTypeId { get; set; }
    public string? IDCard { get; set; }
    public string? TaxCode { get; set; }
}

