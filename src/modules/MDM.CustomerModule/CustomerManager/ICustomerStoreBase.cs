using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;
using System.Linq.Expressions;

namespace MDM.CustomerModule.CustomerManager;

public interface ICustomerStoreBase
{
    IQueryable<PartiesBase> GetAllCustomer(GetAllCustomerModel input);
    IQueryable<PartiesBase> GetAsync(GetPartyModel input);
    IQueryable<CustomerType> GetCustomerTypes(params Expression<Func<CustomerType, object>>[] propertySelectors);
}
