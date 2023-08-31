using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using FluentValidation;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Models;
using MDM.CustomerModule.PartyManager;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Identity.Application.BillingApp;

public class BillingCustomerService : AsyncCrudAppService<BillingCustomer, BillingCustomerModel, Guid, GetAllBillingCustomerModel, CreateBillingCustomerModel, UpdateBillingCustomerModel, GetBillingCustomerModel, DeleteBillingCustomerModel>, IBillingCustomerService
{
    private readonly IRepository<PartyRoleAssignment, Guid> _partyRoleAssignmentRepository;
    private readonly IPartyRoleAssignmentStoreBase _partyRoleAssignmentStoreBase;

    public BillingCustomerService(IRepository<BillingCustomer, Guid> repository, IRepository<PartyRoleAssignment, Guid> partyRoleAssignmentRepository, IPartyRoleAssignmentStoreBase partyRoleAssignmentStoreBase) : base(repository)
    {
        _partyRoleAssignmentRepository = partyRoleAssignmentRepository;
        _partyRoleAssignmentStoreBase = partyRoleAssignmentStoreBase;
    }

    protected override IQueryable<BillingCustomer> CreateFilteredQuery(GetAllBillingCustomerModel input)
    {
        var partyRoleAssigns = _partyRoleAssignmentStoreBase.GetByPartyAsync(input.PartyId, nameof(CustomerBase)).GetAwaiter().GetResult();

        if (partyRoleAssigns == null)
            throw new UserFriendlyException("ERR_PARTYROLEASSIGNMENT_HAVE_NOT_CUSTOMER_ROLE");

        var query = base.CreateFilteredQuery(input);
        var partyRoleAssign = partyRoleAssigns.FirstOrDefault();
        var billings = query
                .Include(p => p.Address)
                .Include(p => p.Email)
                .Include(p => p.TelePhone)
                .Where(p => p.CustomerId == partyRoleAssign.SourceId)
                .WhereIf(!string.IsNullOrEmpty(input.Search), x => x.CompanyName.ToUpper().Trim().Contains(input.Search.ToUpper().Trim())
                    || x.Email.EmailAddress.ToUpper().Trim().Contains(input.Search.ToUpper().Trim())
                    || x.TaxCode.ToUpper().Trim().Contains(input.Search.ToUpper().Trim()));

        return query;
    }

    protected override IQueryable<BillingCustomer> ApplySorting(IQueryable<BillingCustomer> query, GetAllBillingCustomerModel input)
    {
        return base.ApplySorting(query, input);
    }
    
    protected override IQueryable<BillingCustomer> ApplyPaging(IQueryable<BillingCustomer> query, GetAllBillingCustomerModel input)
    {
        return base.ApplyPaging(query, input);
    }

    public override Task<PagedResultDto<BillingCustomerModel>> GetAllAsync(GetAllBillingCustomerModel input)
    {
        return base.GetAllAsync(input);
    }
}

