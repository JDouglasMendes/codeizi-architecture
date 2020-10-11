using Codeizi.DI.Helper.Anotations;
using Codeizi.Infra.Core.UOW;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Codeizi.Infra.Data.Context
{
    // Change name for your project

    public sealed class CodeiziContext : DbContext, IUnitOfWork
    {
        public CodeiziContext(
            DbContextOptions<CodeiziContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<bool> Commit()
            => await SaveChangesAsync() > 0;

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

            modelBuilder.
                ApplyConfigurationsFromAssembly(GetType().Assembly,
                                                type => type.FullName.EndsWith("Map"));

            base.OnModelCreating(modelBuilder);
        }
    }
}