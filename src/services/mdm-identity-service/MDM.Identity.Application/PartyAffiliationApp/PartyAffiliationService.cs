using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Json;
using Abp.Linq.Extensions;
using Abp.Timing;
using Abp.UI;
using Identity.Core.Entities;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.DynamicCustomer;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;
using Microsoft.EntityFrameworkCore;
using PartyAffiliationEntity = MDM.CustomerModule.Entity.PartyModel.PartyAffiliation;
namespace Identity.Application.PartyAffiliationApp;

public class PartyAffiliationService : AsyncCrudAppService<PartyAffiliationEntity, PartyAffiliationModel, Guid, GetAllPartyAffiliationModel, CreatePartyAffiliationModel, UpdatePartyAffiliationModel, GetPartyAffiliationModel, DeletePartyAffiliationModel>, IPartyAffiliationService
{
    private readonly IRepository<CustomerAttributeValue, Guid> _customerAttributeValueRepository;
    private readonly IRepository<EmployeeBase, Guid> _employeeBaseRepository;
    private readonly IRepository<PartyAffiliationType, Guid> _partyAffiliationTypeRepository;

    public PartyAffiliationService(IRepository<PartyAffiliationEntity, Guid> repository, IRepository<CustomerAttributeValue, Guid> customerAttributeValueRepository, IRepository<EmployeeBase, Guid> employeeBaseRepository, IRepository<PartyAffiliationType, Guid> partyAffiliationTypeRepository) : base(repository)
    {
        _customerAttributeValueRepository = customerAttributeValueRepository;
        _employeeBaseRepository = employeeBaseRepository;
        _partyAffiliationTypeRepository = partyAffiliationTypeRepository;
    }


    protected override IQueryable<PartyAffiliationEntity> CreateFilteredQuery(GetAllPartyAffiliationModel input)
    {
        input.ToJsonString();
        var query  = Repository.GetAllIncluding()
            .Include(p => p.PartyAffiliationType)
                .Include(p => p.Party)
                .Include(p => p.SubParty)
                .Where(p => p.ExpirationDate == null || p.ExpirationDate > Clock.Now)
                .WhereIf(input.PartyId.HasValue, s => s.PartyId == input.PartyId.Value || s.SubPartyId == input.PartyId.Value)
                .WhereIf(input.PartyAffiliationTypeId.HasValue, s => s.PartyAffiliationTypeId == input.PartyAffiliationTypeId);
        
        return query;
    }

    public override async Task<PagedResultDto<PartyAffiliationModel>> GetAllAsync(GetAllPartyAffiliationModel input)
    {
        var query = CreateFilteredQuery(input);
        var totalCount = await AsyncQueryableExecuter.CountAsync(query);
        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);

        return new PagedResultDto<PartyAffiliationModel>(totalCount, entities.Select(MapToEntityDto).ToList());
    }

    public override Task<PartyAffiliationModel> CreateAsync(CreatePartyAffiliationModel input)
    {
        return base.CreateAsync(input);
    }

    public override Task<PartyAffiliationModel> UpdateAsync(UpdatePartyAffiliationModel input)
    {
        return base.UpdateAsync(input);
    }

    public async Task<List<PartyAffiliationModel>> GetAllByHierarchicalAsync(GetAllByHierarchicalModel model)
    {
        var partyAffilli = await Repository.GetAll()
                .Include(p => p.PartyAffiliationType)
                .Include(p => p.Party)
                .Include(p => p.SubParty)
                .WhereIf(model.PartyId.HasValue, s => s.PartyId == model.PartyId)
                .WhereIf(model.PartyAffiliationTypeIds?.Count > 0, s => model.PartyAffiliationTypeIds.Contains(s.PartyAffiliationTypeId))
                .ToListAsync();

        var result = new List<PartyAffiliationModel>();
        partyAffilli.ForEach(p =>
        {
            var party = ObjectMapper.Map<PartyAffiliationModel>(p.Party);
            var subParty = ObjectMapper.Map<PartyAffiliationModel>(p.SubParty);

            var partyAffiliation = ObjectMapper.Map<PartyAffiliationModel>(p);
            partyAffiliation.PartyName = party.PartyName;
            partyAffiliation.SubPartyName = subParty.SubPartyName;

            result.Add(partyAffiliation);
        });

        var categoriesList = new List<PartyAffiliationModel>();
        categoriesList = result
            .Where(p => !(result.Select(s => s.SubPartyId).Contains(p.PartyId)))
            .GroupBy(p => p.PartyId).Select(p => p.FirstOrDefault())
            .Select(c => new PartyAffiliationModel()
            {
                Id = c.Id,
                PartyId = c.PartyId,
                PartyName = c.PartyName,
                PartyAffiliationTypeId = c.PartyAffiliationTypeId,
                PartyAffiliationTypeName = c.PartyAffiliationTypeName,
                EffectiveDate = c.EffectiveDate,
                ExpirationDate = c.ExpirationDate,
                PartyAffiliationModels = GetChildren(result, c.PartyId)
            }).ToList();

        return categoriesList;
    }

    public List<PartyAffiliationModel> GetChildren(List<PartyAffiliationModel> categories, Guid parentId)
    {
        return categories
            .Where(p => p.PartyId == parentId)
            .Select(c => new PartyAffiliationModel
            {
                Id = c.Id,
                PartyId = c.PartyId,
                SubPartyId = c.SubPartyId,
                SubPartyName = c.SubPartyName,
                PartyAffiliationTypeId = c.PartyAffiliationTypeId,
                PartyAffiliationTypeName = c.PartyAffiliationTypeName,
                EffectiveDate = c.EffectiveDate,
                ExpirationDate = c.ExpirationDate,
                PartyAffiliationModels = GetChildren(categories, c.SubPartyId)
            }).ToList();
    }

    public async Task<PartyAffiliationModel> GetBySubPartyAsync(Guid partyId)
    {
        var partyAffiliation = await Repository.FirstOrDefaultAsync(p => p.SubPartyId == partyId);
        if (partyAffiliation == null)
            throw new UserFriendlyException("ERR_PARTYAFFILIATION_NOT_FOUND");

        return ObjectMapper.Map<PartyAffiliationModel>(partyAffiliation);
    }

    public async Task<bool> CreateOrDeleteAffiliationAgencyAsync(AffiliationAgencyModel input)
    {
        //tìm KH (ĐL)
        var customer = _customerAttributeValueRepository.GetAll()
                .Include(p => p.Customer)
                .FirstOrDefault(p => p.Value.ToUpper().Trim().Equals(input.CustomerDTCode.ToUpper().Trim()));

        if (customer == null)
            throw new UserFriendlyException("ERR_PARTY_NOT_FOUND");

        ////tìm nhân viên
        var employee = _employeeBaseRepository.GetAll()
                .Include(p => p.Party).ThenInclude(s => s.PartyIdentification).FirstOrDefault();

        if (employee == null)
            throw new UserFriendlyException("ERR_SUBPARTY_NOT_FOUND");

        //tạo mối quan hệ
        var partyAffiliationType = await _partyAffiliationTypeRepository.FirstOrDefaultAsync(p => p.Id == input.AfiliationTypeId);
        if (partyAffiliationType == null)
            throw new UserFriendlyException("ERR_PARTYAFFILIATIONTYPE_NOT_FOUND");

        if (input.Action == 1) //create
        {
            var checkExist = Repository.FirstOrDefault(p => p.PartyId == customer.Customer.PartyId && p.SubPartyId == employee.PartyId && (p.ExpirationDate == null || p.ExpirationDate > Clock.Now));

            if (checkExist != null)
                throw new UserFriendlyException("ERR_PARTYAFFILIATION_EXISTED");

            var partyAffiliation = ObjectMapper.Map<PartyAffiliationEntity>(input);
            partyAffiliation.PartyId = customer.Customer.PartyId;
            partyAffiliation.SubPartyId = employee.PartyId;
            partyAffiliation.EffectiveDate = Clock.Now;
            await Repository.InsertAsync(partyAffiliation);
            return true;
        }
        else if (input.Action == 2) //delete
        {
            var checkExist = Repository.FirstOrDefault(p => p.PartyId == customer.Customer.PartyId && p.SubPartyId == employee.PartyId
                                                       && (p.ExpirationDate == null || p.ExpirationDate > Clock.Now));
            if (checkExist != null)
            if (checkExist != null)
            {
                checkExist.ExpirationDate = Clock.Now;
                await Repository.DeleteAsync(checkExist);
                return true;
            }
        }

        return false;
    }

    public async Task<PagedResultDto<PartyAffiliationModel>> GetAllSalesAsync(GetAllPartyAffiliationModel input)
    {
        var query = Repository.GetAll()
                .Include(p => p.PartyAffiliationType)
                .Include(p => p.Party)
                .Include(p => p.SubParty).ThenInclude(s => s.Employee)
                .Where(p => p.ExpirationDate == null || p.ExpirationDate > Clock.Now)
                .Where(p => p.SubParty.Employee.EmployeeTypeId != null)
                .WhereIf(input.PartyId.HasValue, s => s.PartyId == input.PartyId.Value || s.SubPartyId == input.PartyId.Value)
                .WhereIf(input.PartyAffiliationTypeId.HasValue, s => s.PartyAffiliationTypeId == input.PartyAffiliationTypeId.Value);

        ApplySorting(query, input);

        var list = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();
        var result = new List<PartyAffiliationModel>();
        list.ToList().ForEach(p =>
        {
            var party = ObjectMapper.Map<PartyAffiliationModel>(p.Party);
            var subParty = ObjectMapper.Map<PartyAffiliationModel>(p.SubParty);

            var partyAffiliation = ObjectMapper.Map<PartyAffiliationModel>(p);
            partyAffiliation.PartyName = party.PartyName;
            partyAffiliation.SubPartyName = subParty.SubPartyName;

            result.Add(partyAffiliation);
        });

        return new PagedResultDto<PartyAffiliationModel>(query.Count(), ObjectMapper.Map<List<PartyAffiliationModel>>(result));
    }

    public async Task<PagedResultDto<PartyAffiliationModel>> GetAllAffiliationAgencyAsync(GetAllPartyAffiliationModel input)
    {
        var query = Repository.GetAll()
                .Include(p => p.PartyAffiliationType)
                .Include(p => p.Party)
                .Include(p => p.SubParty)
                .Where(p => p.ExpirationDate == null || p.ExpirationDate > Clock.Now)
                .WhereIf(input.PartyId.HasValue, s => s.PartyId == input.PartyId.Value)
                .WhereIf(input.SubPartyId.HasValue, s => s.SubPartyId == input.SubPartyId.Value)
                .WhereIf(input.PartyAffiliationTypeId.HasValue, s => s.PartyAffiliationTypeId == input.PartyAffiliationTypeId.Value);

        ApplySorting(query, input);

        var partyAffiliations = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

        var result = new List<PartyAffiliationModel>();
        partyAffiliations.ToList().ForEach(entity =>
        {
            var party = ObjectMapper.Map<PartyAffiliationModel>(entity.Party);
            var subParty = ObjectMapper.Map<PartyAffiliationModel>(entity.SubParty);
            var partyAffiliation = ObjectMapper.Map<PartyAffiliationModel>(entity);
            partyAffiliation.PartyName = party.PartyName;
            partyAffiliation.SubPartyName = subParty.SubPartyName;

            result.Add(partyAffiliation);
        });

        return new PagedResultDto<PartyAffiliationModel>(query.Count(), ObjectMapper.Map<List<PartyAffiliationModel>>(result));
    }
}

