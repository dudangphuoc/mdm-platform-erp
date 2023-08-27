using Abp.Application.Services.Dto;
using Newtonsoft.Json;

namespace MDM.CustomerModule.Models;

public class PartyAffiliationModel : EntityDto<Guid>
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }

    /// <summary>
    /// Tên party (thực thể/ đối tượng).
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string PartyName { get; set; }

    /// <summary>
    /// Id sub party (thực thể/ đối tượng con).
    /// </summary>
    public Guid SubPartyId { get; set; }

    /// <summary>
    /// Tên sub party (thực thể/ đối tượng).
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string SubPartyName { get; set; }

    /// <summary>
    /// Id loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyAffiliationTypeId { get; set; }

    /// <summary>
    /// Tên loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public string PartyAffiliationTypeName { get; set; }

    /// <summary>
    /// Mô tả loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public string? PartyAffiliationTypeDescription { get; set; }

    /// <summary>
    /// Ngày hiệu lực.
    /// </summary>
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Ngày hết hạn.
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<PartyAffiliationModel>? PartyAffiliationModels { get; set; }
}
