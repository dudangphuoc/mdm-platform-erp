using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using FluentValidation;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.Validations;

public class ContactMethodTypeValidator : AbstractValidator<CreateContactMethodTypeModel>
{

    public ContactMethodTypeValidator()
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

