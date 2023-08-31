using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;
using Newtonsoft.Json;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(BillingCustomer))]
public class BillingCustomerModel : EntityDto<Guid>
{
    /// <summary>
    /// Id KH (đại lý).
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Id KH (đại lý).
    /// </summary>
    public Guid? PartyId { get; set; }

    /// <summary>
    /// Tên liên lạc.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    public string? TelephoneNumber { get; set; }

    /// <summary>
    /// Mã số thuế.
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Tên đường.
    /// </summary>
    public string? AddressLine { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? EmailAddress { get; set; }

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
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}
