using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using AuthorizationModule.MultiTenancy;
using MDM.CatalogModule;
using MDM.Common.EntityFactory;
using MDM.CustomerModule;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyModel;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

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
            
            foreach (var type in RegisterDbSet.ShouldHasAttribute(
                typeof(CatalogModule).GetAssembly(),
                typeof(CatalogModule).GetAssembly(),
                typeof(CustomerModule).GetAssembly()))
            {
                modelBuilder.Entity(type);
            }
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
            modelBuilder.ConfigureBaseService();
            ConfigureBaseService(modelBuilder);
        }
        public void ConfigureBaseService( ModelBuilder builder)
        {
            builder.Entity<PartyRoleAssignment>(entity =>
            {
                entity.Property(b => b.Source).HasConversion(
                                       v => string.Join(',', v),
                                                          v => v.Split(',', System.StringSplitOptions.RemoveEmptyEntries));
            });
            builder.Entity<PartyAffiliation>(b =>
            {
                b.HasOne<PartiesBase>(s => s.Party)
                 .WithMany(p => p.PartyAffiliations);
                b.HasOne(p => p.SubParty)
                    .WithMany(p => p.SubPartyAffiliations)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CustomerBase>()
            .HasOne<PartyRoleAssignment>(s => s.PartyRoleAssignment)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PartyRoleAssignment>()
            .HasOne<CustomerBase>()
            .WithOne(ad => ad.PartyRoleAssignment);

            builder.Entity<Team>(p =>
            {
                p.HasIndex(s => s.Name);
                p.HasIndex(s => s.Code);
                p.HasMany(p => p.Teams).WithOne().HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<TeamHistory>(p =>
            {
                p.HasIndex(s => s.TeamName);
                p.HasOne(p => p.Team).WithOne().HasForeignKey<TeamHistory>(p => p.TeamId).OnDelete(DeleteBehavior.NoAction);
            });
        }




    }
}
