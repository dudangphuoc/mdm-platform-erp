using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.UI;
using FluentValidation;
using FluentValidation.Results;
using MDM.CustomerModule.Entity.PartyContact;

namespace Identity.Application.ContactMethodApp;
public class DeleteContactMethodTypeModel : EntityDto<Guid>
{
}

public class GetContactMethodTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class UpdateContactMethodTypeModel : CreateContactMethodTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class CreateContactMethodTypeModel
{
    /// <summary>
    /// Tên loại phương thức liên hệ
    /// </summary>
    public string Name { get; set; }
}

public class GetAllContactMethodTypeModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Tên loại phương thức liên hệ
    /// </summary>
    public string Name { get; set; }
}

[AutoMap(typeof(PartyIdentification))]
public class ContactMethodTypeModel : EntityDto<Guid>
{
    public Guid PartyId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    public string? IDCard { get; set; }

    public string? TaxCode { get; set; }
}

public class ContactMethodTypeValidator : AbstractValidator<CreateContactMethodTypeModel>
{

    public ContactMethodTypeValidator()
    {
        RuleFor(s => s.Name).NotNull().NotEmpty().WithMessage("ERR_CONTACTMETHODTYPE_NAME_NOT_NULL");
        RuleFor(s => s.Name).MaximumLength(200).WithMessage("ERR_CONTACTMETHODTYPE_NAME_MAX_LENGTH_200");
        RuleFor(x => x.Name).MustAsync(async (name, cancellation) =>
        {
            using(var uow = IocManager.Instance.ResolveAsDisposable<IUnitOfWorkManager>())
            using (var repo = IocManager.Instance.ResolveAsDisposable<IRepository<PartyContactType, Guid>>())
            {
                 return await repo.Object.CountAsync(p => p.Name.ToLower().Trim().Equals(name.ToLower().Trim())) > 0;
            }
        }).WithMessage("ERR_CONTACTMETHODTYPE_NAME_EXISTED");
    }
}

public class UpdateContactMethodTypeValidator : AbstractValidator<UpdateContactMethodTypeModel>
{

    public UpdateContactMethodTypeValidator()
    {
        RuleFor(s => s.Name).NotNull().NotEmpty().WithMessage("ERR_CONTACTMETHODTYPE_NAME_NOT_NULL");
        RuleFor(s => s.Name).MaximumLength(200).WithMessage("ERR_CONTACTMETHODTYPE_NAME_MAX_LENGTH_200");
        RuleFor(x => x.Name).MustAsync(async (name, cancellation) =>
        {
            using (var uow = IocManager.Instance.ResolveAsDisposable<IUnitOfWorkManager>())
            using (var repo = IocManager.Instance.ResolveAsDisposable<IRepository<PartyContactType, Guid>>())
            {
                return await repo.Object.CountAsync(p => p.Name.ToLower().Trim().Equals(name.ToLower().Trim())) > 0;
            }
        }).WithMessage("ERR_CONTACTMETHODTYPE_NAME_EXISTED");
    }
}


public interface IContactMethodTypeService : IAsyncCrudAppService<ContactMethodTypeModel, Guid, GetAllContactMethodTypeModel, CreateContactMethodTypeModel, UpdateContactMethodTypeModel, GetContactMethodTypeModel, DeleteContactMethodTypeModel>
{

}

public class ContactMethodTypeService : AsyncCrudAppService<PartyContactType, ContactMethodTypeModel, Guid, GetAllContactMethodTypeModel, CreateContactMethodTypeModel, UpdateContactMethodTypeModel, GetContactMethodTypeModel, DeleteContactMethodTypeModel>, IContactMethodTypeService
{
    public ContactMethodTypeService(IRepository<PartyContactType, Guid> repository) : base(repository)
    {

    }

    protected override IQueryable<PartyContactType> CreateFilteredQuery(GetAllContactMethodTypeModel input)
    {
        var query = base.CreateFilteredQuery(input)
                .WhereIf(!string.IsNullOrEmpty(input.Name), x => x.Name.Contains(input.Name));

        return query;
    }

    public override async Task<ContactMethodTypeModel> GetAsync(GetContactMethodTypeModel input)
    {
        var partyContactType = await Repository.FirstOrDefaultAsync(input.Id);
        if (partyContactType == null)
            throw new UserFriendlyException("ERR_CONTACTMETHODTYPE_NOT_FOUND");

        return ObjectMapper.Map<ContactMethodTypeModel>(partyContactType);
    }
}

