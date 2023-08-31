using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.EmployeeApp;

public interface IEmployeeTypeService : IAsyncCrudAppService<EmployeeTypeModel, Guid, GetAllEmployeeTypeModel, CreateEmployeeTypeModel, UpdateEmployeeTypeModel, GetEmployeeTypeModel, DeleteEmployeeTypeModel>
{

}

