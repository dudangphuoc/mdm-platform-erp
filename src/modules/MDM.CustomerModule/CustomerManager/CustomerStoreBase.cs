﻿using Abp.Dependency;
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


    public CustomerStoreBase(IRepository<CustomerBase, Guid> repository, IRepository<PersonBase, Guid> personRepository, IRepository<CustomerType, Guid> customerTypeRepository)
    {
        CustomerRepository = repository;
        PersonRepository = personRepository;
        CustomerTypeRepository = customerTypeRepository;
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
            var personQuery = PersonRepository.GetAll().Where(x => x.Name.Contains(input.Name.ToUpper().Trim()));
            var resultQuery = from parties in partiesQuery
                              join tPerson in personQuery on parties.Id equals tPerson.Id into t2
                              from person in t2.DefaultIfEmpty()
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
