using MDM.ModuleBase;

namespace MDM.CustomerModule.Models;

public class CreatePartyModel
{
    /// <summary>        
    /// Id loại party.
    /// </summary>
    public Guid? PartyTypeId { get; set; }

    /// <summary>        
    /// Loại role party.
    /// </summary>
    public Guid? PartyRoleTypeId { get; set; }

    /// <summary>        
    /// Loại khách hàng (customer, agent...).
    /// </summary>
    public Guid? CustomerTypeId { get; set; }

    /// <summary>        
    /// Loại nhân viên (cs, cước, sales...).
    /// </summary>
    public Guid? EmployeeTypeId { get; set; }

    /// <summary>
    /// Tên khách hàng/ đại lý.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Tên đầy đủ khách hàng/ đại lý.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    public string? TelePhoneNumber { get; set; }

    /// <summary>
    /// Mã số thuế.
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Ngày sinh.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Giới tính.
    /// </summary>
    public EGender? Gender { get; set; }

    /// <summary>
    /// Ghi chú.
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// Id loại phương thức liên hệ.
    /// </summary>
    public Guid? ContactMethodTypeId { get; set; }

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
    /// Tên đường.
    /// </summary>
    public string? AddressLine { get; set; }

    /// <summary>
    /// Danh sách property dynamic.
    /// </summary>
    public List<CreateAtttributeModel>? Attributes { get; set; }
}

