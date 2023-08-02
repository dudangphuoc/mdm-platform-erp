using Abp.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationModule.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
            Description = DisplayName ?? "";
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
            Description = displayName??"";
        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
            Description = displayName ?? "";
        }

       

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
