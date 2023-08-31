using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Timing;
using FluentValidation;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.Validations;
public class PartyAffiliationValidator : AbstractValidator<CreatePartyAffiliationModel>
{
    public PartyAffiliationValidator()
    {
        RuleFor(p => p.PartyId).NotNull().NotEmpty().WithMessage("ERR_PARTY_ID_NOT_NULL").MustAsync(async (PartyId, cancellation) =>
        {
            using (var ioc = IocManager.Instance.ResolveAsDisposable<IRepository<PartiesBase, Guid>>())
            {
                var existed = await ioc.Object.FirstOrDefaultAsync(p => p.Id == PartyId);
                return existed != null;
            }
        }).WithMessage("ERR_PARTY_NOT_FOUND");

        RuleFor(p => p.SubPartyId).NotNull().NotEmpty().WithMessage("ERR_SUBPARTY_ID_NOT_NULL").MustAsync(async (SubPartyId, cancellation) =>
        {
            using (var ioc = IocManager.Instance.ResolveAsDisposable<IRepository<PartiesBase, Guid>>())
            {
                var existed = await ioc.Object.FirstOrDefaultAsync(p => p.Id == SubPartyId);
                return existed != null;
            }
        }).WithMessage("ERR_SUBPARTY_NOT_FOUND");

        RuleFor(p => p.PartyAffiliationTypeId).NotNull().NotEmpty().WithMessage("ERR_PARTYAFFILIATIONTYPE_ID_NOT_NULL").MustAsync(async (PartyAffiliationTypeId, cancellation) =>
        {
            using (var ioc = IocManager.Instance.ResolveAsDisposable<IRepository<PartyType, Guid>>())
            {
                var existed = await ioc.Object.FirstOrDefaultAsync(p => p.Id == PartyAffiliationTypeId);
                
                return existed != null;
            }
        });

        RuleFor(p => p).MustAsync(async (item, cancellation) =>
        {
            using (var partiesRepository = IocManager.Instance.ResolveAsDisposable<IRepository<PartiesBase, Guid>>())
            using (var partyAffiliationReposytory = IocManager.Instance.ResolveAsDisposable<IRepository<PartyAffiliation, Guid>>())
            {
                var partiesQuery = partiesRepository.Object.GetAll().Where(p => p.Id == item.PartyId).Select(s => s.Id);
                var subpartyQuery = partiesRepository.Object.GetAll().Where(p => p.Id == item.SubPartyId).Select(s => s.Id);
                var checkExist = partyAffiliationReposytory.Object.FirstOrDefault(p =>
                    partiesQuery.Contains(p.PartyId)
                    &&
                    subpartyQuery.Contains(p.SubPartyId)
                    &&
                    (p.ExpirationDate == null || p.ExpirationDate > Clock.Now)
                    );

                return checkExist == null;
            }
        }).WithMessage("ERR_PARTYAFFILIATION_EXISTED");
    }
}
