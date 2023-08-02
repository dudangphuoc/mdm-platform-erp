using Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationModule.DataTransferObject.Accounts
{
    public class IsTenantAvailableInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
