using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Timing;
using Abp.UI;
using FluentValidation;
using Identity.Core.Entities;
using MDM.Common.Validations;
using MDM.CustomerModule;
using MDM.CustomerModule.CustomerManager;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Entity.Person;
using MDM.CustomerModule.Models;
using MDM.ModuleBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Z.EntityFramework.Plus;

namespace Identity.Application.CustomerApp;

public class CustomerService : IdentityAppServiceBase, ICustomerService
{
    protected ICustomerStoreBase CustomerStore;
    protected IRepository<Customer, Guid> CustomerRepository;
    protected IRepository<CustomerType, Guid> CustomerTypeRepository;
    protected IRepository<PartyRoleType, Guid> PartyRoleTypeRepository;
    protected IRepository<PartyType, Guid> PartyTypeRepository;
    protected IRepository<TelePhone, Guid> TelePhoneRepository;
    protected IRepository<PartyIdentification, Guid> PartyIdentificationRepository;
    protected IRepository<Organization, Guid> OrganizationRepository;
    protected IRepository<PartyRoleAssignment, Guid> PartyRoleAssignmentRepository;
    protected IRepository<Address, Guid> AddressRepository;
    protected IRepository<Email, Guid> EmailRepository;
    protected IRepository<PartyContactType, Guid> PartyContactTypeRepository;
    protected IRepository<PartyContactMethod, Guid> PartyContactMethodRepository;
    protected IRepository<PersonBase, Guid> PersonRepository;
    protected IRepository<PartiesBase, Guid> PartiesBaseRepository;

    //
    public CustomerService(ICustomerStoreBase customerStore, IRepository<Customer, Guid> customerRepository, IRepository<CustomerType, Guid> customerTypeRepository, IRepository<PartyRoleType, Guid> partyRoleTypeRepository, IRepository<PartyType, Guid> partyTypeRepository, IRepository<TelePhone, Guid> telePhoneRepository, IRepository<PartyIdentification, Guid> partyIdentificationRepository, IRepository<Organization, Guid> organizationRepository, IRepository<PartyRoleAssignment, Guid> partyRoleAssignmentRepository, IRepository<Address, Guid> addressRepository, IRepository<Email, Guid> emailRepository, IRepository<PartyContactType, Guid> partyContactTypeRepository, IRepository<PartyContactMethod, Guid> partyContactMethodRepository, IRepository<PersonBase, Guid> personBaseRepository, IRepository<PartiesBase, Guid> partiesBaseRepository)
    {
        CustomerStore = customerStore;
        CustomerRepository = customerRepository;
        CustomerTypeRepository = customerTypeRepository;
        PartyRoleTypeRepository = partyRoleTypeRepository;
        PartyTypeRepository = partyTypeRepository;
        TelePhoneRepository = telePhoneRepository;
        PartyIdentificationRepository = partyIdentificationRepository;
        OrganizationRepository = organizationRepository;
        PartyRoleAssignmentRepository = partyRoleAssignmentRepository;
        AddressRepository = addressRepository;
        EmailRepository = emailRepository;
        PartyContactTypeRepository = partyContactTypeRepository;
        PartyContactMethodRepository = partyContactMethodRepository;
        PersonRepository = personBaseRepository;
        PartiesBaseRepository = partiesBaseRepository;
    }

    public async Task<PagedResultDto<PartySearchModel>> GetAllAsync(GetAllCustomerModel input)
    {
        var query = CustomerStore.GetAllCustomer(input);
        var total = await CustomerRepository.CountAsync();

        if (!input.Sorting.IsNullOrWhiteSpace())
            query = query.OrderBy(input.Sorting);
        if (input is ILimitedResultRequest)
            query = query.OrderByDescending(e => e.Id);

        query = query.Skip(input.SkipCount).Take(input.MaxResultCount);
        var result = new PagedResultDto<PartySearchModel>(total, ObjectMapper.Map<List<PartySearchModel>>(query));

        return result;
    }

    public async Task<PartyModel> GetAsync(GetPartyModel input)
    {
        var party = CustomerStore.GetAsync(input).FirstOrDefault();

        if (party?.Customer == null)
            throw new UserFriendlyException("ERR_CUSTOMER_NOT_FOUND");

        return ObjectMapper.Map<PartyModel>(party);
    }

    public async Task<PartyModel> CreateAsync(CreatePartyModel input)
    {
        PartyRoleType? partyRoleType = await ValidPartyModel(input, PartyTypeConsts.OrganizationKey);

        var organization = ObjectMapper.Map<Organization>(new Organization()
        {
            OrganizationName = input.Name,
            FullName = input.FullName,
            Remark = input.Remark,
            PartyTypeId = input.PartyTypeId??default(Guid),
            IsActive = true
        });
        organization = await OrganizationRepository.InsertAsync(organization);

        //role
        var partyRoleAssign = ObjectMapper.Map<PartyRoleAssignment>(new PartyRoleAssignment()
        {
            PartyId = organization.Id,
            PartyRoleTypeId = partyRoleType.Id,
            EffectiveDate = Clock.Now
        });
        partyRoleAssign = await PartyRoleAssignmentRepository.InsertAsync(partyRoleAssign);

        _ = await AddCustomer(input, organization.Id, partyRoleAssign);

        //định danh, contact
        await AddPartyidentification(input, organization.Id, partyRoleAssign.Id, organization.PartyTypeId, organization.OrganizationName);

        var mapper = ObjectMapper.Map<PartyModel>(organization);

        return mapper;
    }

    public async Task<PartyModel> CreatePersonAsync(CreatePartyModel input)
    {
        PartyRoleType?  partyRoleType = await ValidPartyModel(input, PartyTypeConsts.PersonKey);

        var person = ObjectMapper.Map<PersonBase>(new PersonBase()
        {
            PartyTypeId = partyRoleType.Id,
            Name = input.Name,
            FullName = input.FullName,
            Remark = input.Remark,
            DateOfBirth = input.DateOfBirth == null ? null : input.DateOfBirth.Value,
            Gender = input.Gender == null ? null : input.Gender.Value,
            IsActive = true
        });
        person = await PersonRepository.InsertAsync(person);

        //role
        var partyRoleAssign = ObjectMapper.Map<PartyRoleAssignment>(new PartyRoleAssignment()
        {
            PartyId = person.Id,
            PartyRoleTypeId = partyRoleType.Id,
            EffectiveDate = Clock.Now
        });
        partyRoleAssign = await PartyRoleAssignmentRepository.InsertAsync(partyRoleAssign);

        var customer = await AddCustomer(input, person.Id, partyRoleAssign);

        ////định danh, contact
        await AddPartyidentification(input, person.Id, partyRoleAssign.Id, person.PartyTypeId, person.Name);
        var mapper = ObjectMapper.Map<PartyModel>(person);
        return mapper;
    }

    public async Task<PartyModel> UpdateAsync(UpdatePartyModel input)
    {
        var party = PartiesBaseRepository.GetAll()
                .Include(p => p.PartyIdentification)
                    .ThenInclude(s => s.TelePhone)
                .Include(p => p.PartyIdentification)
                    .ThenInclude(s => s.Email)
                .Include(p => p.PartyIdentification)
                    .ThenInclude(s => s.Address)
                .Include(p => p.PartyType)
                .Include(p => p.Customer)
                    .ThenInclude(a => a.PartyRoleAssignment)
                    .ThenInclude(a => a.PartyRoleType)
                .Include(p => p.Customer)
                    .ThenInclude(s => s.PartyRoleAssignment)
                    .ThenInclude(s => s.PartyContactMethods)
                .Include(p => p.Customer)
                    .ThenInclude(s => s.CustomerType)
                .Where(p => p.Customer != null)
                .FirstOrDefault(p => p.Id == input.Id && p.IsActive == true);

        if (party == null)
            throw new UserFriendlyException("ERR_PARTY_NOT_FOUND");

        var partyRoleTypes  = PartyRoleTypeRepository.GetAll().FromCache().ToList();
        var customerTypes = CustomerTypeRepository.GetAll().FromCache().ToList();
        var partyTypes = PartyTypeRepository.GetAll().FromCache().ToList();

        if (partyTypes.Count() == 0)
            throw new UserFriendlyException("ERR_PARTYTYPE_NOT_FOUND");

        if (party.PartyTypeId == partyTypes.Where(x => x.Name.Equals(PartyTypeConsts.PersonKey)).Select(x => x.Id).FirstOrDefault())
        {
            var person = await PersonRepository.FirstOrDefaultAsync(input.Id);
            person.Gender = input.Gender == null ? null : input.Gender.Value;
            person.Name = input.Name;
            person.FullName = input.FullName;
            person.Remark = input.Remark;
            person.DateOfBirth = input.DateOfBirth == null ? null : input.DateOfBirth.Value;
            person = await PersonRepository.UpdateAsync(person);

            await UpdatePartyidentification(input, party);
        }
        else if (party.PartyTypeId == partyTypes.Where(x => x.Name.Equals(PartyTypeConsts.OrganizationKey)).Select(x => x.Id).FirstOrDefault())
        {
            var organization = await OrganizationRepository.FirstOrDefaultAsync(input.Id);
            organization.OrganizationName = input.Name;
            organization.FullName = input.FullName;
            organization.Remark = input.Remark;
            organization = await OrganizationRepository.UpdateAsync(organization);

            await UpdatePartyidentification(input, party);
        }
        else
        {
            throw new UserFriendlyException("ERR_PARTYTYPE_NOT_FOUND");
        }

        //update thông tin role
        if (party.Customer != null)
        {
            party.Customer.CustomerTypeId = input.CustomerTypeId.Value;
            var customerMapper = ObjectMapper.Map<UpdatePartyRoleModel>(party.Customer);
            var customer = await UpdateRoleCustomerAsync(customerMapper);
        }
        var mapper = ObjectMapper.Map<PartyModel>(party);

        return mapper;
    }

    private async Task<PartyRoleType> ValidPartyModel(CreatePartyModel input, string partyType)
    {
        var partyRoleTypes  = PartyRoleTypeRepository.GetAll().FromCache().ToList();
        var customerTypes = CustomerTypeRepository.GetAll().FromCache().ToList();
        var partyTypes = PartyTypeRepository.GetAll().FromCache().ToList();

        if (partyRoleTypes.Count() == 0)
            throw new UserFriendlyException("ERR_ROLETYPE_NOT_FOUND");
        if (customerTypes.Count() == 0)
            throw new UserFriendlyException("ERR_CUSTOMERTYPE_NOT_FOUND");
        if (partyTypes.Count() == 0 && partyTypes.Where(x => x.Name == partyType).Select(s => s.Id).Count() == 0)
            throw new UserFriendlyException("ERR_PARTYTYPE_NOT_FOUND");

        var customerType = partyRoleTypes.Where(x => x.Id == input.CustomerTypeId.Value).FirstOrDefault();
        if (customerType == null)
            throw new UserFriendlyException("ERR_CUSTOMERTYPE_NOT_FOUND");
        input.PartyTypeId = partyTypes.Where(x => x.Name == partyType).Select(s => s.Id).FirstOrDefault();
        await CheckPartyidentification(input);

        return customerType;
    }

    private async Task<Customer> AddCustomer(CreatePartyModel input, Guid partyId, PartyRoleAssignment partyRoleAssign)
    {
        var customer = ObjectMapper.Map<Customer>(new Customer()
        {
            PartyId = partyId,
            PartyRoleAssignmentId = partyRoleAssign.Id,
            CustomerTypeId = input.CustomerTypeId.Value,
        });

        customer = await CustomerRepository.InsertAsync(customer);

        return customer;
    }

    private async Task AddPartyidentification(CreatePartyModel input, Guid partyId, Guid? partyRoleAssignId, Guid partyTypeId, string name = null)
    {
        var contact = await AddContact(ObjectMapper.Map<CreatePartyContactModel>(input), partyRoleAssignId, name);


        var partyTypes = PartyTypeRepository.GetAll().FromCache().ToList();
        var partyIdentificationTypes = PartyIdentificationTypeRepository.GetAll().FromCache();
        var telephone = partyIdentificationTypes.Where(x => x.Name.Equals(PartyIdentificationType.nameOfTelePhoneNumber)).FirstOrDefault();


        if (partyIdentificationTypes.Where(x => x.Name.Equals(PartyIdentificationType.nameOfTelePhoneNumber)).FirstOrDefault() == null)
        {
            throw new UserFriendlyException("ERR_IDENTIFICATION_TYPE_NOT_FOUND");
        }
        var identification = ObjectMapper.Map<PartyIdentification>(new PartyIdentification()
        {
            PartyId = partyId,
            PartyIdentificationTypeId = telephone.Id,
            TelePhoneId = contact.TelephoneId,
            TaxCode = input.TaxCode,
            EmailId = contact.EmailId,
            AddressId = contact.AddressId,
        });
        identification = await PartyIdentificationRepository.InsertAsync(identification);
    }

    //tạo email/address/telephone trong lúc tạo party
    private async Task<PartyContactModel> AddContact(CreatePartyContactModel input, Guid? partyRoleAssignId, string name = null)
    {
        //address
        var address = new Address();
        if (!string.IsNullOrEmpty(input.AddressLine) || input.CountryId.HasValue || input.ProvinceId.HasValue
            || input.DistrictId.HasValue || input.WardId.HasValue)
        {
            var countryId = input.CountryId != null ? input.CountryId.Value : Guid.Empty;
            var provinceId = input.ProvinceId != null ? input.ProvinceId.Value : Guid.Empty;
            var districtId = input.DistrictId != null ? input.DistrictId.Value : Guid.Empty;
            var wardId = input.WardId != null ? input.WardId.Value : Guid.Empty;

            //address
            address = await AddressRepository.FirstOrDefaultAsync(p =>
                p.AddressLine.ToUpper().Trim().Equals(input.AddressLine.ToUpper().Trim())
                && p.CountryId == countryId
                && p.ProvinceId == provinceId
                && p.DistrictId == districtId
                && p.WardId == wardId);

            if (address == null)
            {
                address = ObjectMapper.Map<Address>(new Address()
                {
                    AddressLine = input.AddressLine,
                    CountryId = countryId,
                    ProvinceId = provinceId,
                    DistrictId = districtId,
                    WardId = wardId
                });
                address = await AddressRepository.InsertAsync(address);
            }
        }

        //telephone
        var telephone = await TelePhoneRepository.FirstOrDefaultAsync(p => p.TelephoneNumber == input.TelephoneNumber);
        if (telephone == null)
        {
            telephone = ObjectMapper.Map<TelePhone>(new TelePhone()
            {
                TelephoneNumber = input.TelephoneNumber
            });
            telephone = await TelePhoneRepository.InsertAsync(telephone);
        }

        //email
        var email = new Email();
        if (!string.IsNullOrEmpty(input.EmailAddress))
        {
            email = await EmailRepository.FirstOrDefaultAsync(p => p.EmailAddress.ToLower().Trim().Equals(input.EmailAddress.ToLower().Trim()));
            if (email == null)
            {
                email = ObjectMapper.Map<Email>(new Email()
                {
                    EmailAddress = input.EmailAddress
                });
                email = await EmailRepository.InsertAsync(email);
            }
        }

        var partyContactType = await PartyContactTypeRepository.FirstOrDefaultAsync(p => p.Name == "Contact");

        var contact = await PartyContactMethodRepository.FirstOrDefaultAsync(p => p.PartyRoleAssignmentId == partyRoleAssignId &&
                                                                            p.TelephoneId == telephone.Id
                                                                            && p.EmailId == (email.Id == Guid.Empty ? null : email.Id)
                                                                            && p.AddressId == (address.Id == Guid.Empty ? null : address.Id));
        if (contact == null)
        {
            var checkIsDefault = PartyContactMethodRepository.GetAll().Any(p => p.PartyRoleAssignmentId == partyRoleAssignId && p.IsDefault == true);
            contact = ObjectMapper.Map<PartyContactMethod>(new PartyContactMethod()
            {
                PartyRoleAssignmentId = partyRoleAssignId.Value,
                PartyContactTypeId = input.ContactMethodTypeId ?? partyContactType.Id,
                AddressId = address != null ? address.Id == Guid.Empty ? null : address.Id : null,
                TelephoneId = telephone.Id,
                EmailId = email != null ? email.Id == Guid.Empty ? null : email.Id : null,
                ContactName = input.ContactName ?? name,
                EffectiveDate = Clock.Now,
                IsDefault = checkIsDefault == true ? false : true
            });
            //contact = await _partyContactMethodRp.InsertAsync(contact);
        }
        var result = ObjectMapper.Map<PartyContactModel>(contact);
        return result;
    }

    private async Task CheckPartyidentification(CreatePartyModel input)
    {
        var telephone = await TelePhoneRepository.FirstOrDefaultAsync(p => p.TelephoneNumber == input.TelePhoneNumber);
        var identification = await PartyIdentificationRepository.GetAll()
                    .Include(p => p.Party)
                    .FirstOrDefaultAsync(p => p.TelePhoneId == (telephone != null ? telephone.Id: Guid.Empty));
        var customerTypes = CustomerTypeRepository.GetAll().FromCache().ToList();
        var customerId = customerTypes.Where(x => x.Name.Equals(CustomerTypeConsts.CustomerKey)).FirstOrDefault();
        if (input.CustomerTypeId == customerId?.Id) //khách lẻ
        {
            //check sđt                
            if (telephone != null)
            {
                if (identification != null)
                    throw new UserFriendlyException("ERR_PHONENUMBER_EXISTED");
            }

            if (!string.IsNullOrEmpty(input.EmailAddress))
            {
                var email = await EmailRepository.FirstOrDefaultAsync(p => p.EmailAddress.Trim() == input.EmailAddress.Trim());
                if (email != null)
                {
                    var identificationEmail = await PartyIdentificationRepository.FirstOrDefaultAsync(p => p.EmailId == email.Id);

                    if (identificationEmail != null)
                        throw new UserFriendlyException("ERR_EMAIL_EXISTED");
                }
            }
        }
        else //doanh nghiệp/ đại lý
        {
            var partyTypes = PartyTypeRepository.GetAll().FromCache().ToList();
            var partyTypeId  = partyTypes.Where(x => x.Name.Equals(PartyTypeConsts.PersonKey)).Select(x => x.Id).FirstOrDefault();
            if (input.PartyTypeId == partyTypeId) //đại lý lẻ
            {
                if (telephone != null)
                {
                    if (identification != null)
                        throw new UserFriendlyException("ERR_PHONENUMBER_EXISTED");
                }
            }
            else // đại lý theo DN
            {
                //check MST
                var identificationTax= await PartyIdentificationRepository.FirstOrDefaultAsync(p => p.TaxCode.Trim().Equals(input.TaxCode.Trim()));

                if (identificationTax != null)
                    throw new UserFriendlyException("ERR_TAXCODE_EXISTED");
            }
        }
    }

    private async Task UpdatePartyidentification(UpdatePartyModel input, PartiesBase party)
    {
        var contact = ObjectMapper.Map<PartyContactModel>(new PartyContactModel());
        var identification = party.PartyIdentification;

        var partyTypes = PartyTypeRepository.GetAll().FromCache().ToList();
        var partyRoleTypeId  = PartyRoleTypeRepository.GetAll().FromCache().Where(x => x.Name.Equals(CustomerTypeConsts.CustomerKey)).Select(x => x.Id).FirstOrDefault();

        var partyRoleAssign = await PartyRoleAssignmentRepository.FirstOrDefaultAsync(p => p.PartyId == party.Id
                                                                                && p.PartyRoleTypeId == partyRoleTypeId
                                                                                && (p.ExpirationDate == null || p.ExpirationDate > Clock.Now));
        if (partyRoleAssign != null)
        {
            var contacts = party.Customer.PartyRoleAssignment.PartyContactMethods;
            if (contacts != null)
            {
                var item = contacts.Where(p => p.PartyRoleAssignmentId == partyRoleAssign.Id && p.TelephoneId == identification.TelePhoneId
                                            && p.EmailId == identification.EmailId && p.AddressId == identification.AddressId).FirstOrDefault();
                if (item != null)
                {
                    //nếu có contact thì update lại contact đó
                    var mapper = ObjectMapper.Map<UpdatePartyContactModel>(input);
                    mapper.PartyId = party.Id;
                    mapper.Id = item.Id;
                    mapper.ContactName = input.Name;
                    contact = await UpdateContact(mapper, partyRoleAssign.Id, item.AddressType);
                }
            }

            //ngược lại thì thêm mới
            if (contact != null && contact.Id == Guid.Empty)
            {
                contact = await AddContact(ObjectMapper.Map<CreatePartyContactModel>(input), partyRoleAssign.Id, input.Name);
            }

            if (identification.TelePhoneId != contact.TelephoneId)
            {
                //update phone
                if (!string.IsNullOrEmpty(input.TelePhoneNumber))
                {
                    identification.TelePhoneId = contact.TelephoneId;
                }
                else
                {
                    identification.TelePhoneId = null;
                }
            }

            if (identification.EmailId != contact.EmailId)
            {
                //update email
                if (!string.IsNullOrEmpty(input.EmailAddress))
                {
                    identification.EmailId = contact.EmailId;
                }
                else
                {
                    identification.EmailId = null;
                }
            }

            if (identification.AddressId != contact.AddressId)
            {
                //update address
                if (!string.IsNullOrEmpty(input.AddressLine))
                {
                    identification.AddressId = contact.AddressId;
                }
                else
                {
                    identification.AddressId = null;
                }
            }

            //update taxcode
            if (!string.IsNullOrEmpty(input.TaxCode))
            {
                identification.TaxCode = input.TaxCode;
            }

            identification = await PartyIdentificationRepository.UpdateAsync(identification);
        }
    }

    //tạo contact trong lúc tạo party
    private async Task<PartyContactModel> UpdateContact(UpdatePartyContactModel input, Guid? partyRoleAssignId, EAddressType? addressType = null)
    {
        var partyContactMethod = await PartyContactMethodRepository.GetAll()
               .Include(p => p.Address)
               .Include(p => p.Email)
               .Include(p => p.TelePhone)
               .FirstOrDefaultAsync(p => p.Id == input.Id);

        //address
        var address = new Address();
        if (!string.IsNullOrEmpty(input.AddressLine) || input.CountryId.HasValue || input.ProvinceId.HasValue
            || input.DistrictId.HasValue || input.WardId.HasValue)
        {
            var countryId = input.CountryId != null ? input.CountryId.Value : Guid.Empty;
            var provinceId = input.ProvinceId != null ? input.ProvinceId.Value : Guid.Empty;
            var districtId = input.DistrictId != null ? input.DistrictId.Value : Guid.Empty;
            var wardId = input.WardId != null ? input.WardId.Value : Guid.Empty;

            //address
            address = await AddressRepository.FirstOrDefaultAsync(p => p.AddressLine.ToUpper().Trim().Equals(input.AddressLine.ToUpper().Trim())
                                                                && p.CountryId == countryId
                                                                && p.ProvinceId == provinceId
                                                                && p.DistrictId == districtId
                                                                && p.WardId == wardId);
            if (address == null)
            {
                address = ObjectMapper.Map<Address>(new Address()
                {
                    AddressLine = input.AddressLine,
                    CountryId = countryId,
                    ProvinceId = provinceId,
                    DistrictId = districtId,
                    WardId = wardId
                });
                address = await AddressRepository.InsertAsync(address);
            }
        }

        //telephone
        var telephone = await TelePhoneRepository.FirstOrDefaultAsync(p => p.TelephoneNumber == input.TelephoneNumber);
        if (telephone == null)
        {
            telephone = ObjectMapper.Map<TelePhone>(new TelePhone()
            {
                TelephoneNumber = input.TelephoneNumber
            });
            telephone = await TelePhoneRepository.InsertAsync(telephone);
        }

        //email
        var email = new Email();
        if (!string.IsNullOrEmpty(input.EmailAddress))
        {
            email = await EmailRepository.FirstOrDefaultAsync(p => p.EmailAddress.ToLower().Trim().Equals(input.EmailAddress.ToLower().Trim()));
            if (email == null)
            {
                email = ObjectMapper.Map<Email>(new Email()
                {
                    EmailAddress = input.EmailAddress
                });
                email = await EmailRepository.InsertAsync(email);
            }
        }

        var partyContactType = await PartyContactTypeRepository.FirstOrDefaultAsync(p => p.Name == "Contact");

        var contactIsDefault = PartyContactMethodRepository.GetAll().Where(p => p.PartyRoleAssignmentId == partyRoleAssignId
                                                                        && p.IsDefault == true && p.Id != input.Id).ToList();

        //if (contactIsDefault.Count() == 0 && !input.IsDefault && !partyContactMethod.IsDefault)
        //    throw new VietmapException(ErrorCode.PartyContactMethodErrorCode.ERR_PARTYCONTACTMETHOD_AT_LEAST_ONE_ADDRESS_IS_DEFAULT);

        //check thay đổi contact đã có chưa => nếu r thì lấy item đã có sẵn
        var existContactInput = PartyContactMethodRepository.FirstOrDefault(p => p.PartyRoleAssignmentId == partyRoleAssignId
                                                                            && p.TelephoneId == telephone.Id
                                                                            && p.EmailId == (email.Id == Guid.Empty ? null : email.Id)
                                                                            && p.AddressId == (address.Id == Guid.Empty ? null : address.Id));
        if (existContactInput != null)
        {
            if (existContactInput.Id != partyContactMethod.Id)
            {
                var resultExist = ObjectMapper.Map<PartyContactModel>(existContactInput);
                return resultExist;
            }
        }
        partyContactMethod.AddressId = address != null ? address.Id == Guid.Empty ? null : address.Id : null;
        partyContactMethod.TelephoneId = telephone.Id;
        partyContactMethod.EmailId = email != null ? email.Id == Guid.Empty ? null : email.Id : null;
        partyContactMethod.ContactName = input.ContactName;
        partyContactMethod.IsDefault = (contactIsDefault.Count() == 0 && partyContactMethod.IsDefault) ? partyContactMethod.IsDefault : input.IsDefault;
        partyContactMethod.AddressType = input.AddressType ?? addressType;
        partyContactMethod.PartyContactTypeId = partyContactType.Id;

        //update lai dia chi dang la isdefault
        if (partyContactMethod.IsDefault)
        {
            contactIsDefault.ForEach(async p =>
            {
                p.IsDefault = false;
                //await _partyContactMethodRp.UpdateAsync(p);
            });
        }
        //await _partyContactMethodRp.UpdateAsync(partyContactMethod);

        var result = ObjectMapper.Map<PartyContactModel>(partyContactMethod);
        return result;
    }

    public async Task<PartyRoleModel> UpdateRoleCustomerAsync(UpdatePartyRoleModel input)
    {
        var customer = await CustomerRepository.GetAll()
                .Include(p => p.PartyRoleAssignment)
                .FirstOrDefaultAsync(p => p.Id == input.Id);
        if (customer == null)
            throw new UserFriendlyException("ERR_CUSTOMER_NOT_FOUND");


        var customerType = await CustomerTypeRepository.FirstOrDefaultAsync(input.CustomerTypeId.Value);
        if (customerType == null)
            throw new UserFriendlyException("ERR_CUSTOMERTYPE_NOT_FOUND");

        ObjectMapper.Map(input, customer);
        customer = await CustomerRepository.UpdateAsync(customer);
        var mapper = ObjectMapper.Map<PartyRoleModel>(customer);

        return mapper;
    }
}

