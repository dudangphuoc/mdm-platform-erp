using Abp.Dependency;
using Abp.Domain.Repositories;
using FluentValidation;
using MDM.Common;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.Validations;
public class PartyTypeValidtator : AbstractValidator<CreatePartyTypeModel>
{
    public PartyTypeValidtator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL").MustAsync(async (name, cancellation) =>
        {
            using (var ioc = IocManager.Instance.ResolveAsDisposable<IRepository<PartyType, Guid>>())
            {
                var existed = await ioc.Object.FirstOrDefaultAsync(p => p.NormalizedName == name.ToNoneSignVietnameseNormalized());
                return existed == null;
            }
        }).WithMessage("ERR_PARTYTYPE_NAME_EXISTED");
    }
}
