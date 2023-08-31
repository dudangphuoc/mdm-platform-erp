using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;
public class CustomerTypeGroupService : AsyncCrudAppService<CustomerTypeGroup, CustomerTypeGroupModel, Guid, GetAllCustomerTypeGroupModel, CreateCustomerTypeGroupModel, UpdateCustomerTypeGroupModel, GetCustomerTypeGroupModel, DeleteCustomerTypeGroupModel>, ICustomerTypeGroupService
{
    public CustomerTypeGroupService(IRepository<CustomerTypeGroup, Guid> repository) : base(repository)
    {

    }
}

