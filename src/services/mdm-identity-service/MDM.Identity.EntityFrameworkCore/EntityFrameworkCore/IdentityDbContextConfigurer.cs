using Abp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Data.Common;

namespace Identity.EntityFrameworkCore
{
    public static class IdentityDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdentityDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdentityDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }

       
        public static void ConfigureBaseService(this ModelBuilder builder)
        {

            Check.NotNull(builder, nameof(builder));
            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
        }

    }
}
