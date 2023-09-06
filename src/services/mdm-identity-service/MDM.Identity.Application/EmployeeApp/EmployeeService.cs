using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.Models;

namespace Identity.Application.EmployeeApp;
public class DeleteEmployeeModel : EntityDto<Guid>
{
}

public class GetEmployeeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class UpdateEmployeeModel : CreateEmployeeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class CreateEmployeeModel
{
    public Guid PartyId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    public string? IDCard { get; set; }

    public string? TaxCode { get; set; }
}

public class GetAllEmployeeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên sales.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Trạng thái.
    /// </summary>
    public bool? IsActive { get; set; }
}

//[AutoMap(typeof(PartyIdentification))]
//public class EmployeeModel : EntityDto<Guid>
//{
//    public Guid PartyId { get; set; }

//    public Guid PartyContactTypeId { get; set; }

//    public string? IDCard { get; set; }


//    public string? TaxCode { get; set; }
//}


public interface IEmployeeService : IAsyncCrudAppService<PartyModel, Guid, GetAllEmployeeModel, CreateEmployeeModel, UpdateEmployeeModel, GetEmployeeModel, DeleteEmployeeModel>
{

}

public class EmployeeService : AsyncCrudAppService<PartiesBase, PartyModel, Guid, GetAllEmployeeModel, CreateEmployeeModel, UpdateEmployeeModel, GetEmployeeModel, DeleteEmployeeModel>, IEmployeeService
{

    protected IRepository<EmployeeBase, Guid> EmployeeBaseRepository;
    protected IRepository<PersonBase, Guid> PersonRepository;
    protected IRepository<Organization, Guid> OrganizationRepository;



    public EmployeeService(IRepository<PartiesBase, Guid> repository, IRepository<EmployeeBase, Guid> employeeBaseRepository, IRepository<PersonBase, Guid> personRepository, IRepository<Organization, Guid> organizationRepository) : base(repository)
    {
        EmployeeBaseRepository = employeeBaseRepository;
        PersonRepository = personRepository;
        OrganizationRepository = organizationRepository;
    }

    protected override IQueryable<PartiesBase> CreateFilteredQuery(GetAllEmployeeModel input)
    {
        var partiesQuery = Repository.GetAllIncluding(
            x => x.PartyType,
            x => x.PartyIdentification,
            x => x.Employee.PartyRoleAssignment.PartyRoleType,
            x => x.Employee.CustomerDynamicAtrributeValues)
           .Where(x => x.PartyRoleAssignments.Count > 0)
           .WhereIf(input.IsActive.HasValue, p => p.IsActive == input.IsActive);

        if (!string.IsNullOrEmpty(input.Name))
        {
            var personQuery = PersonRepository.GetAll().Where(x => x.Name.Contains(input.Name.ToUpper().Trim()));
            var organizationQuery = OrganizationRepository.GetAll().Where(p => p.OrganizationName.Contains(input.Name.ToUpper().Trim()));
            var resultQuery = from parties in partiesQuery
                              join org in organizationQuery on parties.Id equals org.Id into t1
                              from organiztion in t1.DefaultIfEmpty()
                              join per in personQuery on parties.Id equals per.Id into t2
                              from person in t2.DefaultIfEmpty()
                              where (person.Name.Contains(input.Name.ToUpper().Trim()) || organiztion.OrganizationName.Contains(input.Name.ToUpper().Trim()))
                                && parties.Employee != null
                              select parties;

            return resultQuery.Distinct();
        }

        return partiesQuery;
    }

}

