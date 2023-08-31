using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public interface ICustomerTypeService : IAsyncCrudAppService<CustomerTypeModel, Guid, GetAllCustomerTypeModel, CreateCustomerTypeModel, UpdateCustomerTypeModel, GetCustomerTypeModel, DeleteCustomerTypeModel>
{

}
