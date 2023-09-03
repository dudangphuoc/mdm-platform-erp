using Abp.Dependency;
using Abp.Domain.Repositories;
using FluentValidation;
using MDM.CustomerModule.Entity.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.CustomerModule.Validations;

public class CustomerSegmentTypeValidator : AbstractValidator<CustomerSegmentType>
{
    public CustomerSegmentTypeValidator()
    {
        RuleFor(s => s.Name).NotNull().NotEmpty().WithMessage("ERR_CUSTOMERSEGMENTTYPE_NAME_NOT_NULL");
        RuleFor(s => s.Name).MaximumLength(500).WithMessage("ERR_CUSTOMERSEGMENTTYPE_NAME_MAX_LENGTH_500");
        RuleFor(x => x.Name).MustAsync(async (name, cancellation) =>
        {
            using (var repo = IocManager.Instance.ResolveAsDisposable<IRepository<CustomerSegmentType, Guid>>())
            {
                var existed = await repo.Object.CountAsync(p => p.Name.ToLower().Trim().Equals(name.ToLower().Trim()));
                return existed == 0;
            }
        }).WithMessage("ERR_CUSTOMERSEGMENTTYPE_NAME_EXISTED");
    }
}