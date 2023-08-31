using Abp.AutoMapper;
using FluentValidation;
using MDM.Common.Validations;
using MDM.CustomerModule.Entity.CustomerModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(BillingCustomer))]
public class CreateBillingCustomerModel
{
    /// <summary>
    /// Id KH (đại lý).
    /// </summary>
    public Guid? PartyId { get; set; }

    /// <summary>
    /// Tên liên lạc.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// Tên đường.
    /// </summary>
    public string? AddressLine { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Số ĐT.
    /// </summary>
    public string? TelephoneNumber { get; set; }

    /// <summary>
    /// Tên liên lạc.
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Id quốc gia.
    /// </summary>
    public Guid? CountryId { get; set; }

    /// <summary>
    /// Id vùng.
    /// </summary>
    public Guid? ProvinceId { get; set; }

    /// <summary>
    /// Id quận.
    /// </summary>
    public Guid? DistrictId { get; set; }

    /// <summary>
    /// Id phường.
    /// </summary>
    public Guid? WardId { get; set; }

    /// <summary>
    /// Mặc định.
    /// </summary>
    public bool IsDefault { get; set; }
}


public class BillingCustomerValidator : AbstractValidator<CreateBillingCustomerModel>
{
    public BillingCustomerValidator()
    {
        RuleFor(p => p.PartyId).NotNull().NotEmpty().WithMessage("ERR_PARTY_ID_NOT_NULL");
        RuleFor(p => p.EmailAddress).NotNull().NotEmpty().WithMessage("ERR_EMAIL_NOT_NULL");
        RuleFor(p => p.AddressLine).NotNull().NotEmpty().WithMessage("ERR_ADDRESS_NOT_NULL");
        RuleFor(p => p.TaxCode).NotNull().NotEmpty().WithMessage("ERR_TAXCODE_NOT_NULL");
        RuleFor(p => p.CompanyName).NotNull().NotEmpty().WithMessage("ERR_COMPANYNAME_NOT_NULL");
        RuleFor(p => p.CountryId).NotNull().NotEmpty().WithMessage("ERR_COUNTRY_NOT_NULL");
        RuleFor(p => p.ProvinceId).NotNull().NotEmpty().WithMessage("ERR_PROVINCE_NOT_NULL");
        RuleFor(p => p.DistrictId).NotNull().NotEmpty().WithMessage("ERR_DISTRICT_NOT_NULL");
        RuleFor(p => p.WardId).NotNull().NotEmpty().WithMessage("ERR_WARD_NOT_NULL");
        RuleFor(p => p.TelephoneNumber).NotNull().NotEmpty().WithMessage("ERR_PHONE_NOT_NULL");
        RuleFor(x => x.TelephoneNumber).Must((telephone, cancellation) =>
        {
            var isValid = PhoneNumberValidation.IsPhoneNbr(telephone.TelephoneNumber);
            return isValid;

        }).WithMessage("ERR_PHONENUMBER_INCORECT_FORMAT");
    }
}
