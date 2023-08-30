using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AuthorizationModule.Authorization.Roles;
using AuthorizationModule.Authorization.Users;
using AuthorizationModule.MultiTenancy;
using Identity.Core;
using Identity.Core.Entities;
using MDM.CatalogModule.Entity.Category;
using MDM.CatalogModule.Entity.Product;
using MDM.Common.EntityFactory;
using MDM.CommonModule.Payment;
using MDM.CommonModule.Tag;
using MDM.CustomerModule.Entity.CustomerModel;
using MDM.CustomerModule.Entity.DynamicCustomer;
using MDM.CustomerModule.Entity.Employee;
using MDM.CustomerModule.Entity.PartyAssignment;
using MDM.CustomerModule.Entity.PartyContact;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Entity.Person;
using MDM.OrderModule.Entities;
using MDM.PaymentModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFrameworkCore;

public class IdentityDbContext : AbpZeroDbContext<Tenant, Role, User, IdentityDbContext>
{
    #region db_set
    public DbSet<PartyType> PartyTypes { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<GiftItem> GiftItems { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Parties> Parties { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<PriceListAssignment> PriceListAssignments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBundle> ProductBundles { get; set; }
    public DbSet<ProductBundleColection> ProductBundleColections { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductGift> ProductGifts { get; set; }
    public DbSet<ProductRelated> ProductRelateds { get; set; }
    public DbSet<ReceiptItem> ReceiptItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ExtensionGroup> ExtensionGroups { get; set; }
    public DbSet<ExtensionName> ExtensionNames { get; set; }
    public DbSet<ExtensionValue> ExtensionValues { get; set; }
    public DbSet<ProductMedia> ProductMedias { get; set; }
    public DbSet<ProductUnit> ProductUnits { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<MDMTag> MDMTags { get; set; }
    public DbSet<TagRelated> TagRelateds { get; set; }
    public DbSet<BillingCustomer> BillingCustomers { get; set; }
    public DbSet<CustomerBase> Customers { get; set; }
    public DbSet<CustomerSegment> CustomerSegments { get; set; }
    public DbSet<CustomerSegmentType> CustomerSegmentTypes { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<CustomerTypeGroup> CustomerTypeGroups { get; set; }
    public DbSet<CustomerAttribute> CustomerAttributes { get; set; }
    public DbSet<CustomerAttributeValue> CustomerAtrributeValues { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<EmployeeBase> Employees { get; set; }
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamHistory> TeamHistories { get; set; }
    public DbSet<PartyRoleAssignment> PartyRoleAssignments { get; set; }
    public DbSet<PartyRoleType> PartyRoleTypes { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<PartyContactMethod> PartyContactMethods { get; set; }
    public DbSet<PartyContactType> PartyContactTypes { get; set; }
    public DbSet<PartyIdentification> PartyIdentifications { get; set; }
    public DbSet<TelePhone> TelePhones { get; set; }
    public DbSet<Website> Websites { get; set; }
    public DbSet<PartyAffiliation> PartyAffiliations { get; set; }
    public DbSet<PartyAffiliationType> PartyAffiliationTypes { get; set; }
    public DbSet<PersonBase> PersonBases { get; set; }
    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<ShippingType> ShippingTypes { get; set; }
    public DbSet<Receipt> Receipts { get; set; } 
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var type in RegisterDbSet.ShouldHasAttribute(typeof(IdentityCoreModule).GetAssembly()))
        {
            modelBuilder.Entity(type);
        }

        modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
        modelBuilder.ConfigureBaseService();
        ConfigureBaseService(modelBuilder);
    }

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
      : base(options)
    {
    }

    public void ConfigureBaseService(ModelBuilder builder)
    {
        builder.Entity<PartyRoleAssignment>(entity =>
        {
            entity.Property(b => b.Source).HasConversion(
                                   v => string.Join(',', v),
                                                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
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

        builder.Entity<ProductBundle>(p =>
        {
            p.HasOne(x => x.Product).WithMany(x => x.ProductBundles).OnDelete(DeleteBehavior.NoAction);
        });
        builder.Entity<ProductBundleColection>(p =>
        {
            p.HasOne(x => x.Product).WithMany(x => x.ProductBundleColections).OnDelete(DeleteBehavior.NoAction);
        });

        ///config product gift
        builder.Entity<Gift>(p =>
        {
            p.HasMany(x => x.Products).WithMany(x => x.Gifts).UsingEntity<ProductGift>(
                l => l.HasOne(x => x.Product).WithMany().HasForeignKey(u => u.ProductId).OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne(x => x.Gift).WithMany().HasForeignKey(u => u.GiftId).OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey(t => new { t.ProductId, t.GiftId });
                });
        });

        ///config product related
        builder.Entity<Product>(p =>
        {
            p.HasMany(x => x.Gifts).WithMany(x => x.Products).UsingEntity<ProductGift>(
                l => l.HasOne(x => x.Gift).WithMany().HasForeignKey(u => u.GiftId).OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne(x => x.Product).WithMany().HasForeignKey(u => u.ProductId).OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey(t => new { t.ProductId, t.GiftId });
                });
        });

        builder.Entity<Branch>(p =>
        {
            p.HasOne(x => x.Party).WithOne(x => x.Branch).OnDelete(DeleteBehavior.NoAction);
            p.HasOne(x => x.PartyRoleAssignment).WithOne().OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<Invoice>(p => {
            p.HasOne(x => x.Order).WithOne(x => x.Invoice).OnDelete(DeleteBehavior.NoAction);
        });


    }
}