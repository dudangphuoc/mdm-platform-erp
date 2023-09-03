using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public interface ICustomerSegmentTypeService : IAsyncCrudAppService<CustomerSegmentTypeModel, Guid, GetAllCustomerSegmentTypeModel, CreateCustomerSegmentTypeModel, UpdateCustomerSegmentTypeModel, GetCustomerSegmentTypeModel, DeleteCustomerSegmentTypeModel>
{
    Task<List<CustomerSegmentTypeModel>> GetAllByIdsAsync(Guid[] ids);
}

