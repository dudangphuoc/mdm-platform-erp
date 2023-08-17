using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using AuthorizationModule.MultiTenancy;
using Identity.Core;
using Identity.Core.Entities;
using MDM.CatalogModule;
using MDM.Common.EntityFactory;
using MDM.CommonModule;
using MDM.CustomerModule;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.OrderModule;
using MDM.PaymentModule;
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
            //

            foreach (var type in RegisterDbSet.ShouldHasAttribute(typeof(IdentityCoreModule).GetAssembly()))
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

            builder.Entity<Payment>(p =>
            {
                p.HasOne(p => p.Party).WithMany().OnDelete(DeleteBehavior.NoAction);
                p.HasOne(p => p.PaymentMethod).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ProductBundle>(p => {
                p.HasOne(x => x.Product).WithMany(x => x.ProductBundles).OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ProductBundleColection>(p => {
                p.HasOne(x => x.Product).WithMany(x => x.ProductBundleColections).OnDelete(DeleteBehavior.NoAction);
            });

            ///config product gift
            builder.Entity<Gift>(p => {
                p.HasMany(x => x.Products).WithMany(x => x.Gifts).UsingEntity<ProductGift>(
                    l => l.HasOne(x => x.Product).WithMany().HasForeignKey(u => u.ProductId).OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(x => x.Gift).WithMany().HasForeignKey(u => u.GiftId).OnDelete(DeleteBehavior.NoAction),
                    j =>
                    {
                        j.HasKey(t => new { t.ProductId, t.GiftId });
                    });
            });

            ///config product related
            builder.Entity<Product>(p => {
                p.HasMany(x => x.Gifts).WithMany(x => x.Products).UsingEntity<ProductGift>(
                    l => l.HasOne(x => x.Gift).WithMany().HasForeignKey(u => u.GiftId).OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(x => x.Product).WithMany().HasForeignKey(u => u.ProductId).OnDelete(DeleteBehavior.NoAction),
                    j =>
                    {
                        j.HasKey(t => new { t.ProductId, t.GiftId });
                    });
            });
        }
    }
}
