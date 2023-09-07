using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using FluentValidation;
using MDM.Common.Validations;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.EntityTypeService;
using MDM.CustomerModule.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

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

public class EmployeeValidator : AbstractValidator<CreatePartyModel>
{
    public EmployeeValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL");
        RuleFor(p => p.EmployeeTypeId).NotNull().NotEmpty().WithMessage("ERR_EMPLOYEE_TYPE_NOT_NULL");
    }
}

public interface IEmployeeService : IAsyncCrudAppService<PartyModel, Guid, GetAllEmployeeModel, CreatePartyModel, UpdateEmployeeModel, GetEmployeeModel, DeleteEmployeeModel>
{

}

public class EmployeeService : AsyncCrudAppService<PartiesBase, PartyModel, Guid, GetAllEmployeeModel, CreatePartyModel, UpdateEmployeeModel, GetEmployeeModel, DeleteEmployeeModel>, IEmployeeService
{
    protected IEmployeeTypeModel EmployeeTypeModel;
    protected IRepository<EmployeeBase, Guid> EmployeeRepository;
    protected IRepository<EmployeeType, Guid> EmployeeTypeRepository;
    protected IRepository<PersonBase, Guid> PersonRepository;
    protected IRepository<Organization, Guid> OrganizationRepository;



    public EmployeeService(IRepository<PartiesBase, Guid> repository, IRepository<EmployeeBase, Guid> employeeBaseRepository, IRepository<PersonBase, Guid> personRepository, IRepository<Organization, Guid> organizationRepository, IRepository<EmployeeType, Guid> employeeTypeRepository, IEmployeeTypeModel employeeTypeModel) : base(repository)
    {
        EmployeeRepository = employeeBaseRepository;
        PersonRepository = personRepository;
        OrganizationRepository = organizationRepository;
        EmployeeTypeRepository = employeeTypeRepository;
        EmployeeTypeModel = employeeTypeModel;
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

    public override async Task<PagedResultDto<PartyModel>> GetAllAsync(GetAllEmployeeModel input)
    {
        var query = CreateFilteredQuery(input);
        var totalCount = await EmployeeRepository.CountAsync();
        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);

        var entities = await AsyncQueryableExecuter.ToListAsync(query);

        return new PagedResultDto<PartyModel>(
            totalCount,
            entities.Select(MapToEntityDto).ToList()
        );
    }

    protected override async Task<PartiesBase> GetEntityByIdAsync(Guid id)
    {
        var partiesQuery = Repository.GetAllIncluding(
            x => x.PartyType,
            x => x.PartyIdentification,
            x => x.Employee.EmployeeType,
            x => x.Employee.PartyRoleAssignment.PartyRoleType,
            x => x.Employee.CustomerDynamicAtrributeValues).Where(x => x.Employee != null);
        var party = partiesQuery.FirstOrDefault(x => x.Id == id && x.IsActive == true);
        if (party == null)
            throw new UserFriendlyException("ERR_PARTY_NOT_FOUND");
      
        return party;
    }

    public void CheckPhone(CreatePartyModel input)
    {
        if (input.EmployeeTypeId == EmployeeTypeModel.AgencyEmployee)
        {
            if (string.IsNullOrEmpty(input.TelePhoneNumber))
                throw new UserFriendlyException("ERR_PHONENUMBER_NOT_NULL");
            else if (!PhoneNumberValidation.IsPhoneNbr(input.TelePhoneNumber))
                throw new UserFriendlyException("ERR_PHONENUMBER_INCORECT_FORMAT");
        }
        else
        {
            if (string.IsNullOrEmpty(input.EmailAddress))
                throw new UserFriendlyException("ERR_EMAIL_NOT_NULL");
        }
    }

    public override Task<PartyModel> CreateAsync(CreatePartyModel input)
    {
       
        CheckPhone(input);
        return base.CreateAsync(input);
    }

}

