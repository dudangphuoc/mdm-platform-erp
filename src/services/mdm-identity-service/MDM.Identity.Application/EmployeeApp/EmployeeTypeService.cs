using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Models;

namespace Identity.Application.EmployeeApp;

public class EmployeeTypeService : AsyncCrudAppService<EmployeeType, EmployeeTypeModel, Guid, GetAllEmployeeTypeModel, CreateEmployeeTypeModel, UpdateEmployeeTypeModel, GetEmployeeTypeModel, DeleteEmployeeTypeModel>, IEmployeeTypeService
{
    public EmployeeTypeService(IRepository<EmployeeType, Guid> repository) : base(repository)
    {

    }
}

