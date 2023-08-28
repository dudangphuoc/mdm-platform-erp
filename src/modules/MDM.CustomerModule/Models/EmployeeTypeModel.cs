using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(EmployeeType))]
public class EmployeeTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại nhân viên.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Diễn giải.
    /// </summary>
    public string Desc { get; set; }
}
