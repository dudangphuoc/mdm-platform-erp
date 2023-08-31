using Abp.AutoMapper;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(EmployeeType))]
public class CreateEmployeeTypeModel
{
    /// <summary>
    /// Tên loại nhân viên
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mô tả loại nhân viên
    /// </summary>
    public string Desc { get; set; }
}

