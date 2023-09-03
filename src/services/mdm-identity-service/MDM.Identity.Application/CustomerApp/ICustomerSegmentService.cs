using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.CustomerApp;

public interface ICustomerSegmentService : IAsyncCrudAppService<CustomerSegmentModel, Guid, GetAllCustomerSegmentModel, CreateCustomerSegmentModel, UpdateCustomerSegmentModel, GetCustomerSegmentModel, DeleteCustomerSegmentModel>
{
    Task<List<CustomerSegmentModel>> GetByCustomerId(Guid partyId);
    Task<List<CustomerSegmentModel>> GetCustomerSegmentByCustomerIdAsync(Guid partyId);
}

