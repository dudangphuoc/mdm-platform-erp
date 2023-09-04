using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.ModuleBase;
using Newtonsoft.Json;

namespace MDM.CustomerModule.Models;
[AutoMap(typeof(PartyContactMethod))]
public class PartyContactModel : EntityDto<Guid>
{
    /// <summary>
    /// Id loại role party (thực thể/ đối tượng).
    /// </summary>        
    public Guid PartyRoleTypeId { get; set; }

    /// <summary>
    /// Tên loại role party (thực thể/ đối tượng).
    /// </summary>
    public string PartyRoleTypeName { get; set; }

    /// <summary>
    /// Tên liên lạc.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ContactName { get; set; }

    /// <summary>
    /// Tên đường.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string AddressLine { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    public string TelephoneNumber { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Id quốc gia.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Guid? CountryId { get; set; }

    /// <summary>
    /// Tên quốc gia.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? CountryName { get; set; }

    /// <summary>
    /// Id vùng.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Guid? ProvinceId { get; set; }

    /// <summary>
    /// Tên vùng.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? ProvinceName { get; set; }

    /// <summary>
    /// Id quận.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Guid? DistrictId { get; set; }

    /// <summary>
    /// Tên quận.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? DistrictName { get; set; }

    /// <summary>
    /// Id phường.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Guid? WardId { get; set; }

    /// <summary>
    /// Tên phường.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? WardName { get; set; }

    /// <summary>
    /// Mặc định.
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Id địa chỉ.
    /// </summary>
    public Guid? AddressId { get; set; }

    /// <summary>
    /// Id số đt.
    /// </summary>
    public Guid? TelephoneId { get; set; }

    /// <summary>
    /// Id email.
    /// </summary>
    public Guid? EmailId { get; set; }

    /// <summary>
    /// Id loại phương thức liên hệ.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Guid ContactMethodTypeId { get; set; }

    /// <summary>
    /// Tên loại phương thức liên hệ.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ContactMethodTypeName { get; set; }

    /// <summary>
    /// Loại địa chỉ.
    /// </summary>        
    public EAddressType? AddressType { get; set; }

    /// <summary>
    /// Tên loại địa chỉ.
    /// </summary>
    public string? AddressTypeName { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}