using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(EmployeeType))]
public class UpdateEmployeeTypeModel : CreateEmployeeTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

