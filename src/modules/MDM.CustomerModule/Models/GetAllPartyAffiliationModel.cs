using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetAllPartyAffiliationModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid? PartyId { get; set; }

    /// <summary>
    /// Id subparty (thực thể/ đối tượng) con.
    /// </summary>
    public Guid? SubPartyId { get; set; }

    /// <summary>
    /// Id loại mối quan hệ (thực thể/ đối tượng).
    /// </summary>
    public Guid? PartyAffiliationTypeId { get; set; }
}
