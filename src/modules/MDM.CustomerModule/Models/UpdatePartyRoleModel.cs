using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(CustomerBase),
       typeof(Branch),
       typeof(EmployeeBase))]
public class CreatePartyRoleModel
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
    /// Loại nhân viên (sales, cs, cước...).
    /// </summary>
    public Guid? EmployeeTypeId { get; set; }

    /// <summary>
    /// Danh sách property dynamic.
    /// </summary>
    public List<CreateAtttributeModel>? Attributes { get; set; }
}

[AutoMap(typeof(CustomerBase),
       typeof(Branch),
       typeof(EmployeeBase))]
public class UpdatePartyRoleModel : CreatePartyRoleModel, IEntityDto<Guid>
{
    /// <summary>
    /// Id role party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}