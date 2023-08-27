using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Timing;
using FluentValidation;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.Validations;

public class UpdatePartyAffiliationValidator : AbstractValidator<UpdatePartyAffiliationModel>
{
    public UpdatePartyAffiliationValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("ERR_PARTY_ID_NOT_NULL").Must(id => {
            using (var partyAffiliationReposytory = IocManager.Instance.ResolveAsDisposable<IRepository<PartyAffiliation, Guid>>())
            {
                var entity = partyAffiliationReposytory.Object.FirstOrDefault(p => p.Id == id);
                return entity != null;
            }
        }).WithMessage("ERR_PARTYAFFILIATION_NOT_FOUND");

        RuleFor(x => x.PartyAffiliationTypeId).NotEmpty().WithMessage("ERR_PARTYAFFILIATIONTYPE_ID_NOT_NULL").Must(partyAffiliationTypeId => {
            using (var partyAffiliationTypeReposytory = IocManager.Instance.ResolveAsDisposable<IRepository<PartyAffiliationType, Guid>>())
            {
                var entity = partyAffiliationTypeReposytory.Object.FirstOrDefault(p => p.Id == partyAffiliationTypeId);
                return entity != null;
            }
        }).WithMessage("ERR_PARTYAFFILIATIONTYPE_NOT_FOUND");

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
