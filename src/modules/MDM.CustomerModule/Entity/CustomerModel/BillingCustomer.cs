using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.CustomerModel;

[InjectContext]
[Table("BillingCustomers")]
public class BillingCustomer : MDMFullAuditedEntityBase
{
    public Guid CustomerId { get; set; }

    public Guid EmailId { get; set; }

    public Guid AddressId { get; set; }

    public Guid TelephoneId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string CompanyName { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string TaxCode { get; set; }

    public bool IsDefault { get; set; }

    [ForeignKey(nameof(EmailId))]
    public Email Email { get; set; }

    [ForeignKey(nameof(AddressId))]
    public Address Address { get; set; }

    [ForeignKey(nameof(TelephoneId))]
    public TelePhone TelePhone { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerBase Customer { get; set; }
}