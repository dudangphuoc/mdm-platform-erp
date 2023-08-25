using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyAssignment;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyRoleAssignment))]
public class PartyRoleAssignmentModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại role.
    /// </summary>
    public string PartyRoleTypeName { get; set; }

    public string? PartyRoleTypeDesc { get; set; }

    /// <summary>
    /// Id loại role.
    /// </summary>
    public Guid PartyRoleTypeId { get; set; }

    ///// <summary>
    ///// Thông tin role customer.
    ///// </summary>        
    //public CustomerRoleModel? Customer { get; set; }

    ///// <summary>
    ///// Thông tin role branch.
    ///// </summary>       
    //public BranchRoleModel? Branch { get; set; }

    public PartyRoleModel? PartyRole { get; set; }

    public DateTime EffectiveDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Danh sách property dynamic.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }

    /// <summary>
    /// Id KH, chi nhanh, nhan vien.
    /// </summary>
    public Guid PartyRoleId { get; set; }

    public string? BranchTeamCode { get; set; }
}
