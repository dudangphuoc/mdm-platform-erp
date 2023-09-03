using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using FluentValidation;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.CustomerApp;

public class CustomerSegmentTypeService : AsyncCrudAppService<CustomerSegmentType, CustomerSegmentTypeModel, Guid, GetAllCustomerSegmentTypeModel, CreateCustomerSegmentTypeModel, UpdateCustomerSegmentTypeModel, GetCustomerSegmentTypeModel, DeleteCustomerSegmentTypeModel>, ICustomerSegmentTypeService
{
    public CustomerSegmentTypeService(IRepository<CustomerSegmentType, Guid> repository) : base(repository)
    {

    }

    protected override IQueryable<CustomerSegmentType> CreateFilteredQuery(GetAllCustomerSegmentTypeModel input)
    {
        var query = base.CreateFilteredQuery(input)
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name));

        return query;
    }

    public override async Task<CustomerSegmentTypeModel> GetAsync(GetCustomerSegmentTypeModel input)
    {
        var customerSegmentType = Repository.GetAll()
                .Include(p => p.CustomerSegments)
                .FirstOrDefault(p => p.Id == input.Id);
        if (customerSegmentType == null)
            throw new UserFriendlyException("ERR_CUSTOMERSEGMENTTYPE_NOT_FOUND");

        return ObjectMapper.Map<CustomerSegmentTypeModel>(customerSegmentType);
    }

    public override async Task<CustomerSegmentTypeModel> CreateAsync(CreateCustomerSegmentTypeModel input)
    {
        var customerSegmentType = ObjectMapper.Map<CustomerSegmentType>(input);


        customerSegmentType = await Repository.InsertAsync(customerSegmentType);
        return ObjectMapper.Map<CustomerSegmentTypeModel>(customerSegmentType);
    }

    public override async Task<CustomerSegmentTypeModel> UpdateAsync(UpdateCustomerSegmentTypeModel input)
    {
        var customerSegmentType = await Repository.FirstOrDefaultAsync(input.Id);
        if (customerSegmentType == null)
            throw new UserFriendlyException("ERR_CUSTOMERSEGMENTTYPE_NOT_FOUND");

        ObjectMapper.Map(input, customerSegmentType);
        customerSegmentType = await Repository.UpdateAsync(customerSegmentType);

        return ObjectMapper.Map<CustomerSegmentTypeModel>(customerSegmentType);
    }


    public async Task<List<CustomerSegmentTypeModel>> GetAllByIdsAsync(Guid[] ids)
    {
        var results = Repository.GetAll()
                .Where(p => ids.Contains(p.Id));
        return ObjectMapper.Map<List<CustomerSegmentTypeModel>>(results);
    }

}

