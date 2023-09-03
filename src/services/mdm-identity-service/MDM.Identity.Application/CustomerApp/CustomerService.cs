using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using FluentValidation;
using MDM.Common.Validations;
using MDM.CustomerModule.CustomerManager;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Models;
using System.Linq.Dynamic.Core;
using Z.EntityFramework.Plus;

namespace Identity.Application.CustomerApp;

public class CustomerOrganizationValidator : AbstractValidator<CreatePartyModel>
{
    public CustomerOrganizationValidator()
    {
        RuleFor(p => p.CustomerTypeId).NotNull().NotEmpty().WithMessage("ERR_CUSTOMERTYPE_ID_NOT_NULL");
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL");
        RuleFor(p => p.TelePhoneNumber).NotNull().NotEmpty().WithMessage("ERR_PHONENUMBER_NOT_NULL");
        RuleFor(p => p.TaxCode).NotNull().NotEmpty().WithMessage("ERR_TAXCODE_NOT_NULL");
        RuleFor(x => x.TelePhoneNumber).Must((telephone, cancellation) =>
        {
            var existed = PhoneNumberValidation.IsPhoneNbr(telephone.TelePhoneNumber);
            return existed;

        }).WithMessage("ERR_PHONENUMBER_INCORECT_FORMAT");
    }
}

public class CustomerService : IdentityAppServiceBase, ICustomerService
{
    protected ICustomerStoreBase CustomerStore;
    protected IRepository<CustomerBase, Guid> CustomerRepository;
    protected IRepository<CustomerType, Guid> CustomerTypeRepository;
    protected IRepository<PartyRoleType, Guid> PartyRoleTypeRepository;


    public CustomerService(ICustomerStoreBase customerStore, IRepository<CustomerBase, Guid> customerRepository, IRepository<CustomerType, Guid> customerTypeRepository, IRepository<PartyRoleType, Guid> partyRoleTypeRepository)
    {
        CustomerStore = customerStore;
        CustomerRepository = customerRepository;
        CustomerTypeRepository = customerTypeRepository;
        PartyRoleTypeRepository = partyRoleTypeRepository;
    }

    public async Task<PagedResultDto<PartySearchModel>> GetAllAsync(GetAllCustomerModel input)
    {
        var query = CustomerStore.GetAllCustomer(input);
        var total = await CustomerRepository.CountAsync();

        if (!input.Sorting.IsNullOrWhiteSpace())
            query = query.OrderBy(input.Sorting);
        if (input is ILimitedResultRequest)
            query = query.OrderByDescending(e => e.Id);

        query = query.Skip(input.SkipCount).Take(input.MaxResultCount);
        var result = new PagedResultDto<PartySearchModel>(total, ObjectMapper.Map<List<PartySearchModel>>(query));

        return result;
    }

    public async Task<PartyModel> GetAsync(GetPartyModel input)
    {
        var party = CustomerStore.GetAsync(input).FirstOrDefault();

        if (party?.Customer == null)
            throw new UserFriendlyException("ERR_CUSTOMER_NOT_FOUND");

        return ObjectMapper.Map<PartyModel>(party);
    }

    public async Task<PartyModel> CreateAsync(CreatePartyModel input)
    {
        var customerType = await CustomerTypeRepository.FirstOrDefaultAsync(input.CustomerTypeId.Value);
        if (customerType == null)
            throw new UserFriendlyException("ERR_CUSTOMERTYPE_NOT_FOUND");
        var partyRoleTypes  = PartyRoleTypeRepository.GetAll().ToList();
        if(partyRoleTypes.Count == 0)
            throw new UserFriendlyException("ERR_ROLETYPE_NOT_FOUND");


        return null;
    }

}

