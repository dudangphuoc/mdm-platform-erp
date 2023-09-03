using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.Models;
using MDM.CustomerModule.PartyManager;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.CustomerApp;

public class CustomerSegmentService : AsyncCrudAppService<CustomerSegment, CustomerSegmentModel, Guid, GetAllCustomerSegmentModel, CreateCustomerSegmentModel, UpdateCustomerSegmentModel, GetCustomerSegmentModel, DeleteCustomerSegmentModel>, ICustomerSegmentService
{
    private readonly IRepository<CustomerBase, Guid> _customerRepository;
    private readonly IRepository<PersonBase, Guid> _personRepository;
    private readonly IRepository<PartyRoleAssignment, Guid>  _partyRoleAssignmentRepository;
    private readonly IPartyRoleAssignmentStoreBase _partyRoleAssignmentStore;

    public CustomerSegmentService(IRepository<CustomerSegment, Guid> repository, IRepository<CustomerBase, Guid> customerRepository, IRepository<PersonBase, Guid> personRepository, IRepository<PartyRoleAssignment, Guid> partyRoleAssignmentRepository, IPartyRoleAssignmentStoreBase partyRoleAssignmentStore) : base(repository)
    {
        _customerRepository = customerRepository;
        _personRepository = personRepository;
        _partyRoleAssignmentRepository = partyRoleAssignmentRepository;
        _partyRoleAssignmentStore = partyRoleAssignmentStore;
    }

    private IQueryable<CustomerSegmentModel> CreateFilteredQuery(GetAllCustomerSegmentModel input)
    {
        var query = from customerSegment in Repository.GetAll()
                        .Include(p => p.CustomerSegmentType)
                        .WhereIf(input.CustomerSegmentTypeId.HasValue, s => s.CustomerSegmentTypeId == input.CustomerSegmentTypeId.Value)
                    join customer in _customerRepository.GetAll() on customerSegment.CustomerId equals customer.Id into t1
                    from customer1 in t1.DefaultIfEmpty()
                    join person in _personRepository.GetAll() on customer1.PartyId equals person.Id into t2
                    from person2 in t2.DefaultIfEmpty()
                    select new CustomerSegmentModel
                    {
                        CustomerId = customerSegment.CustomerId,
                        CustomerName = person2.Name,
                        CustomerSegmentTypeId = customerSegment.CustomerSegmentTypeId.Value,
                        CustomerSegmentTypeName = customerSegment.CustomerSegmentType.Name,
                        Id = customerSegment.Id,
                        CreationTime = customerSegment.CreationTime
                    };

        return query;
    }

    public override async Task<PagedResultDto<CustomerSegmentModel>> GetAllAsync(GetAllCustomerSegmentModel input)
    {
        var query = CreateFilteredQuery(input);

        var totalCount = await AsyncQueryableExecuter.CountAsync(query);

        //Try to sort query if available
        var sortInput = input as ISortedResultRequest;
        if (sortInput != null)
        {
            if (!sortInput.Sorting.IsNullOrWhiteSpace())
            {
                query = System.Linq.Dynamic.Core.DynamicQueryableExtensions.OrderBy(query, sortInput.Sorting);
            }
        }
        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            query = query.OrderByDescending(e => e.Id);
        }

        //Try to use paging if available
        var pagedInput = input as IPagedResultRequest;
        if (pagedInput != null)
        {
            query = query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        var limitedInput = input as ILimitedResultRequest;
        if (limitedInput != null)
        {
            query = query.Take(limitedInput.MaxResultCount);
        }
        var entities = await AsyncQueryableExecuter.ToListAsync(query);

        return new PagedResultDto<CustomerSegmentModel>(
               totalCount,
               entities.ToList()
           );
    }

    public override async Task<CustomerSegmentModel> CreateAsync(CreateCustomerSegmentModel input)
    {

        var partyRoleAssign = (await _partyRoleAssignmentStore.GetByPartyAndMapingAsync(input.PartyId, nameof(CustomerBase))).FirstOrDefault();

        if (partyRoleAssign == null)
            throw new UserFriendlyException("ERR_PARTYROLEASSIGNMENT_NOT_FOUND");

        var existCustomerSegment = await Repository.FirstOrDefaultAsync(p => p.CustomerId == partyRoleAssign.SourceId
                                        && p.CustomerSegmentTypeId == input.CustomerSegmentTypeId);
        if (existCustomerSegment != null)
            throw new UserFriendlyException("ERR_CUSTOMERSEGMENT_EXISTED");

        var customerSegment = ObjectMapper.Map<CustomerSegment>(input);
        customerSegment.CustomerId = partyRoleAssign.SourceId;
        customerSegment = await Repository.InsertAsync(customerSegment);

        return ObjectMapper.Map<CustomerSegmentModel>(customerSegment);
    }

    public async Task<List<CustomerSegmentModel>> GetByCustomerId(Guid partyId)
    {
        var query = await Repository.GetAll()
                    .Include(s => s.Customer)
                    .Include(p => p.CustomerSegmentType)
                    .Where(s => s.Customer.PartyId == partyId)
                    .ToListAsync();

        return ObjectMapper.Map<List<CustomerSegmentModel>>(query);
    }

    public async Task<List<CustomerSegmentModel>> GetCustomerSegmentByCustomerIdAsync(Guid partyId)
    {
        var query = await Repository.GetAll()
                    .Include(s => s.Customer)
                    .Include(p => p.CustomerSegmentType)
                    .Where(s => s.Customer.PartyId == partyId)
                    .ToListAsync();

        return ObjectMapper.Map<List<CustomerSegmentModel>>(query);
    }
}

