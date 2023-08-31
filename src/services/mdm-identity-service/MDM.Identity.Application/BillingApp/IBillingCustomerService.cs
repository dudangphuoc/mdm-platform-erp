using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.BillingApp;

public interface IBillingCustomerService : IAsyncCrudAppService<BillingCustomerModel, Guid, GetAllBillingCustomerModel, CreateBillingCustomerModel, UpdateBillingCustomerModel, GetBillingCustomerModel, DeleteBillingCustomerModel>
{

}

