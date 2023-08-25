using FluentValidation;
using MDM.Common.Validations;
using MDM.CustomerModule.Models;

namespace MDM.CustomerModule.Validations;

public class PartyPersonValidator : AbstractValidator<CreatePartyModel>
{
    public PartyPersonValidator()
    {
        RuleFor(p => p.PartyRoleTypeId).NotNull().NotEmpty().WithMessage("ERR_ROLETYPE_ID_NOT_NULL");
        RuleFor(p => p.PartyTypeId).NotNull().NotEmpty().WithMessage("ERR_PARTYTYPE_ID_NOT_NULL");
    }
}

public class CustomerPersonValidator : AbstractValidator<CreatePartyModel>
{
    public CustomerPersonValidator()
    {
        RuleFor(p => p.CustomerTypeId).NotNull().NotEmpty().WithMessage("ERR_CUSTOMERTYPE_ID_NOT_NULL");
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL");
        RuleFor(p => p.TelePhoneNumber).NotNull().NotEmpty().WithMessage("ERR_PHONENUMBER_NOT_NULL");
        RuleFor(x => x.TelePhoneNumber).Must((telephone, cancellation) =>
        {
            var existed = PhoneNumberValidation.IsPhoneNbr(telephone.TelePhoneNumber);
            return existed;
        }).WithMessage("ERR_PHONENUMBER_INCORECT_FORMAT");
    }
}

public class CustomerOrganizationValidator : AbstractValidator<CreatePartyModel>
{
    public CustomerOrganizationValidator()
    {
        RuleFor(p => p.CustomerTypeId).NotNull().NotEmpty().WithMessage("ERR_CUSTOMERTYPE_ID_NOT_NULL");
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL");
        RuleFor(p => p.TelePhoneNumber).NotNull().NotEmpty().WithMessage("ERR_PHONENUMBER_NOT_NULL");
        RuleFor(p => p.TaxCode).NotNull().NotEmpty().WithMessage("ERR_TAXCODE_NOT_NULL");
        RuleFor(x => x.TelePhoneNumber).Must((telephone, cancellation) =>
        {
            var existed = PhoneNumberValidation.IsPhoneNbr(telephone.TelePhoneNumber);
            return existed;

        }).WithMessage("ERR_PHONENUMBER_INCORECT_FORMAT");
    }
}

public class BranchValidator : AbstractValidator<CreatePartyModel>
{
    public BranchValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("ERR_PARTY_NAME_NOT_NULL");
        RuleFor(p => p.TelePhoneNumber).NotNull().NotEmpty().WithMessage("ERR_PHONENUMBER_NOT_NULL");
        RuleFor(x => x.TelePhoneNumber).Must((telephone, cancellation) =>
        {
            var existed = PhoneNumberValidation.IsPhoneNbr(telephone.TelePhoneNumber);
            return existed;

        }).WithMessage("ERR_PHONENUMBER_INCORECT_FORMAT");
    }
}
