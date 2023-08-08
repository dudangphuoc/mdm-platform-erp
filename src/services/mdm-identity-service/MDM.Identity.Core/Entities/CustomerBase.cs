using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Identity.Core.Entities
{
    public class CustomerBase<TUser> : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public Guid StaffId { get; set; }

        public CustomerStutus CustomerStatus { get; set; }

        public int StaffInChargeNote { get; set; }

        public TUser User { get; set; }

        public int? TenantId { get; set; }
    }
}


