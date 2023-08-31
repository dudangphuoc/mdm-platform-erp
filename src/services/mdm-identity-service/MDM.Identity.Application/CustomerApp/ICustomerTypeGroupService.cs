using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public interface ICustomerTypeGroupService : IAsyncCrudAppService<CustomerTypeGroupModel, Guid, GetAllCustomerTypeGroupModel, CreateCustomerTypeGroupModel, UpdateCustomerTypeGroupModel, GetCustomerTypeGroupModel, DeleteCustomerTypeGroupModel>
{

}

