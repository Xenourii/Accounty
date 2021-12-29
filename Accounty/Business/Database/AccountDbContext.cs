using Accounty.Business.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounty.Business.Database
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(a => new { a.BankName, a.Iban, a.Bic, a.AccountOwner });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added);

            foreach (var entityEntry in entries)
                ((BaseEntity) entityEntry.Entity).CreatedDate = DateTime.UtcNow;

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
