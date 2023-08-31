using Abp.Application.Services.Dto;
using Abp.Dependency;
using FluentValidation;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.PartyManager;

namespace MDM.CustomerModule.Models;

public class GetAllBillingCustomerModel : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }

    /// <summary>
    /// Tìm kiếm theo tên liên hệ/ số ĐT.
    /// </summary>
    public string? Search { get; set; }
}

public class GetAllBillingCustomerValidator : AbstractValidator<GetAllBillingCustomerModel>
{
    public GetAllBillingCustomerValidator()
    {
        RuleFor(x => x.PartyId).NotEmpty().NotNull().MustAsync(async (partyId, cancellationToken) =>
        {
            using (var partyRoleAssignmentStore = IocManager.Instance.ResolveAsDisposable<IPartyRoleAssignmentStoreBase>())
            {
                var partyRoleAssign = (await partyRoleAssignmentStore.Object.GetByPartyAsync(partyId, nameof(CustomerBase))).FirstOrDefaultDynamic();

                return (partyRoleAssign != null);
            }

        }).WithMessage("ERR_PARTYROLEASSIGNMENT_HAVE_NOT_CUSTOMER_ROLE");
    }
}

