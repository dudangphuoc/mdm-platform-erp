using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerBase),
    typeof(Branch),
    typeof(EmployeeBase))]
public class PartyRoleModel : EntityDto<Guid>, IHasCreationTime
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }

    /// <summary>        
    /// Loại role party.
    /// </summary>
    public Guid PartyRoleTypeId { get; set; }

    /// <summary>        
    /// Loại khách hàng (customer, agent...).
    /// </summary>
    public Guid? CustomerTypeId { get; set; }

    /// <summary>        
    /// Tên loại khách hàng (customer, agent...).
    /// </summary>
    public string? CustomerTypeName { get; set; }

    /// <summary>        
    /// Tên loại khách hàng (customer, agent...).
    /// </summary>
    public string? CustomerTypeDesc { get; set; }

    /// <summary>        
    /// Loại nhân viên (sales, cs...).
    /// </summary>
    public Guid? EmployeeTypeId { get; set; }

    /// <summary>        
    /// Tên loại nhân viên (sales, cs...).
    /// </summary>
    public string? EmployeeTypeName { get; set; }

    public string? EmployeeTypeDesc { get; set; }

    /// <summary>
    /// Vô danh.
    /// </summary>
    public bool AnonymousFlag { get; set; }

    /// <summary>
    /// Ngày tạo.
    /// </summary>
    public DateTime CreationTime { get; set; }
}