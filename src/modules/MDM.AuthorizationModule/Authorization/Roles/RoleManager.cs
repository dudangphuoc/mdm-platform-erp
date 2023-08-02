using Abp;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using AuthorizationModule.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AuthorizationModule.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Role, User>
    {
        private IRolePermissionStore<Role> RolePermissionStore
        {
            get
            {
                if (!(Store is IRolePermissionStore<Role>))
                {
                    throw new AbpException("Store is not IRolePermissionStore");
                }

                return Store as IRolePermissionStore<Role>;
            }
        }
        public RoleManager(
            RoleStore store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<AbpRoleManager<Role, User>> logger,
            IPermissionManager permissionManager,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager,
            IRoleManagementConfig roleManagementConfig,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
            : base(
                  store,
                  roleValidators,
                  keyNormalizer,
                  errors, logger,
                  permissionManager,
                  cacheManager,
                  unitOfWorkManager,
                  roleManagementConfig,
                organizationUnitRepository,
                organizationUnitRoleRepository)
        {
        }

        /// <summary>
        /// Tạo permission nếu chưa tồn tại
        /// </summary>
        public async Task RoleConfiguration(int RoleId, string[] Permissions, CancellationToken token)
        {
            var role = await AbpStore.FindByIdAsync(RoleId.ToString(), token);
            if (role == null)
                return;
            foreach (var item in Permissions)
            {
                if (!await RolePermissionStore.HasPermissionAsync(RoleId, new PermissionGrantInfo(item, true)))
                {
                    await RolePermissionStore.AddPermissionAsync(role, new PermissionGrantInfo(item, true));
                }
            }
        }

        /// <summary>
        /// Xóa permission
        /// </summary>
        public async Task DeletePermission(int RoleId, string[] Permissions, CancellationToken token)
        {
            var role = await AbpStore.FindByIdAsync(RoleId.ToString(), token);
            if (role == null)
                return;

            foreach (var item in Permissions)
            {
                if (await RolePermissionStore.HasPermissionAsync(RoleId, new PermissionGrantInfo(item, true)))
                {
                    await RolePermissionStore.RemovePermissionAsync(role, new PermissionGrantInfo(item, true));
                }
            }
        }
    }
}
