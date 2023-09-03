using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;
using Newtonsoft.Json;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartiesBase))]
public class PartySearchModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên party (thực thể/ đối tượng).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Id loại party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyTypeId { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? TelePhoneNumber { get; set; }

    /// <summary>
    /// Mã số thuế.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? TaxCode { get; set; }

    /// <summary>
    /// Tên loại party (thực thể/ đối tượng).
    /// </summary>
    public string PartyTypeName { get; set; }

    /// <summary>
    /// Thông tin role party (thực thể/ đối tượng) được asign.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<PartyRoleAssignmentModel> PartyRoleAssginments { get; set; }

    /// <summary>
    /// Đang hoạt động.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Danh sách property dynamic.
    /// </summary>
    //public Dictionary<string, string> Attributes { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}

