using Abp.Authorization;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;

namespace AuthorizationModule.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
