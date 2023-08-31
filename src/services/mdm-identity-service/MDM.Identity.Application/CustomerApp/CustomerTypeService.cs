using Abp.Application.Services;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public class CustomerTypeService : AsyncCrudAppService<CustomerType, CustomerTypeModel, Guid, GetAllCustomerTypeModel, CreateCustomerTypeModel, UpdateCustomerTypeModel, GetCustomerTypeModel, DeleteCustomerTypeModel>, ICustomerTypeService
{
    public CustomerTypeService(IRepository<CustomerType, Guid> repository) : base(repository)
    {

    }
}