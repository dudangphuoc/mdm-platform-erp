using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.ModuleBase;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartiesBase))]
public class PartyModel : EntityDto<Guid>, IHasCreationTime
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
    public string? TelePhoneNumber { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    public string? AddressLine { get; set; }

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
    /// Mã số thuế.
    /// </summary>        
    public string? TaxCode { get; set; }

    /// <summary>
    /// Tên loại party (thực thể/ đối tượng).
    /// </summary>
    public string PartyTypeName { get; set; }

    public string? PartyTypeDesc { get; set; }

    /// <summary>
    /// Thông tin role party (thực thể/ đối tượng) được asign.
    /// </summary>        
    public List<PartyRoleAssignmentModel> PartyRoleAssginments { get; set; }

    /// <summary>
    /// Thông tin tập KH.
    /// </summary>        
    public List<CustomerSegmentDetailModel> CustomerSegments { get; set; }

    /// <summary>
    /// Đang hoạt động.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Ngày sinh.
    /// </summary>       
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Id giới tính.
    /// </summary>        
    public EGender? Gender { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}
