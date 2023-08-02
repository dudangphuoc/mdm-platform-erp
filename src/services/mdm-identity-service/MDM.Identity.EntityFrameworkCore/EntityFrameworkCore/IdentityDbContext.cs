using Abp.Zero.EntityFrameworkCore;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using AuthorizationModule.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFrameworkCore
{
    public class IdentityDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityDbContext>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
            modelBuilder.ConfigureBaseService();
        }
    }
}
