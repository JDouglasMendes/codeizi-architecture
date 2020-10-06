using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Codeizi.Infra.Data.Context
{
    // Change name for your project
    public sealed class CodeiziContext : DbContext
    {
        public CodeiziContext(
            DbContextOptions<CodeiziContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.
                                        Model.
                                        GetEntityTypes()
                                        .SelectMany(
                                        e => e.GetProperties().
                                            Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

            base.OnModelCreating(modelBuilder);
        }
    }
}