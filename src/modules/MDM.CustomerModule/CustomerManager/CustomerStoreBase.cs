using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;
using System.Linq.Expressions;

namespace MDM.CustomerModule.CustomerManager;

public class CustomerStoreBase : ICustomerStoreBase, ITransientDependency
{
    protected IRepository<CustomerBase, Guid> CustomerRepository;
    protected IRepository<PartiesBase, Guid> PartiesRepository;
    protected IRepository<PersonBase, Guid> PersonRepository;
    protected IRepository<CustomerType, Guid> CustomerTypeRepository;
    protected IRepository<Organization, Guid> OrganizationRepository;

    public CustomerStoreBase(IRepository<CustomerBase, Guid> repository, IRepository<PersonBase, Guid> personRepository, IRepository<CustomerType, Guid> customerTypeRepository, IRepository<Organization, Guid> organizationRepository)
    {
        CustomerRepository = repository;
        PersonRepository = personRepository;
        CustomerTypeRepository = customerTypeRepository;
        OrganizationRepository = organizationRepository;
    }

    public virtual IQueryable<PartiesBase> GetAllCustomer(GetAllCustomerModel input)
    {
        var partiesQuery = PartiesRepository.GetAllIncluding(
            x => x.PartyType,
            x => x.PartyIdentification,
            x => x.Customer,
            x => x.Customer.PartyRoleAssignment)
           .Where(x => x.PartyRoleAssignments.Count > 0)
           .WhereIf(input.IsActive.HasValue, p => p.IsActive == input.IsActive);

        if (!string.IsNullOrEmpty(input.Name))
        {
            var organizationQuery = OrganizationRepository.GetAll().Where(p => p.OrganizationName.Contains(input.Name.ToUpper().Trim()));
            var personQuery = PersonRepository.GetAll().Where(x => x.Name.Contains(input.Name.ToUpper().Trim()));
            var resultQuery =  from parties in partiesQuery
                                join org in organizationQuery on parties.Id equals org.Id into t1
                                from organiztion in t1.DefaultIfEmpty()
                                join per in personQuery on parties.Id equals per.Id into t2
                                from person in t2.DefaultIfEmpty()
                                where (person.Name.Contains(input.Name.ToUpper().Trim()) || organiztion.OrganizationName.Contains(input.Name.ToUpper().Trim()))
                                && parties.PartyRoleAssignments.Count > 0
                                select parties;

            return resultQuery;
        }
     
        return partiesQuery;
    }

    public IQueryable<PartiesBase> GetAsync(GetPartyModel input)
    {
        var partiesQuery = PartiesRepository.GetAllIncluding(
            x => x.PartyIdentification,
            x => x.PartyType,
            x => x.Customer,
            x => x.Customer.PartyRoleAssignment,
            x => x.Customer.PartyRoleAssignment.PartyRoleType,
            x => x.Customer.CustomerSegments,
            x => x.Customer.CustomerType
        ).Where(x => x.Id == input.Id && x.IsActive == true && x.Customer != null);


        return partiesQuery;
    }

    public IQueryable<CustomerType> GetCustomerTypes(params Expression<Func<CustomerType, object>>[] propertySelectors)
    {
        return CustomerTypeRepository.GetAllIncluding(propertySelectors);
    }

}
