using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.Models;

namespace Identity.Application.PersonApp;

public class PersonService : AsyncCrudAppService<PersonBase, PersonModel, Guid, GetAllPersonModel, CreatePersonModel, UpdatePersonModel, GetPersonModel, DeletePersonModel>, IPersonService
{
    public PersonService(IRepository<PersonBase, Guid> repository) : base(repository)
    {

    }

    protected override IQueryable<PersonBase> CreateFilteredQuery(GetAllPersonModel input)
    { 
        var query = base.CreateFilteredQuery(input);
        query.WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name));

        return query;
    }
}

