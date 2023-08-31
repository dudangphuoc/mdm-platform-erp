namespace MDM.CustomerModule.Models;

public class CreatePartyAffiliationModel
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }

    /// <summary>
    /// Id sub party (thực thể/ đối tượng con).
    /// </summary>
    public Guid SubPartyId { get; set; }

    /// <summary>
    /// Id loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyAffiliationTypeId { get; set; }
}
