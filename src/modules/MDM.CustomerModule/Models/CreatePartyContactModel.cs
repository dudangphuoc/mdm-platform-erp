using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.ModuleBase;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyContactMethod))]
public class CreatePartyContactModel
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid? PartyId { get; set; }

    /// <summary>
    /// Id loại phương thức liên hệ.
    /// </summary>
    public Guid? ContactMethodTypeId { get; set; }

    /// <summary>
    /// Tên liên lạc.
    /// </summary>
    public string? ContactName { get; set; }

    /// <summary>
    /// Tên đường.
    /// </summary>
    public string? AddressLine { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    public string? TelephoneNumber { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Id quốc gia.
    /// </summary>
    public Guid? CountryId { get; set; }

    /// <summary>
    /// Id vùng.
    /// </summary>
    public Guid? ProvinceId { get; set; }

    /// <summary>
    /// Id quận.
    /// </summary>
    public Guid? DistrictId { get; set; }

    /// <summary>
    /// Id phường.
    /// </summary>
    public Guid? WardId { get; set; }

    /// <summary>
    /// Loại địa chỉ.
    /// </summary>
    public EAddressType? AddressType { get; set; }

    /// <summary>
    /// Mặc định.
    /// </summary>
    public bool IsDefault { get; set; }
}