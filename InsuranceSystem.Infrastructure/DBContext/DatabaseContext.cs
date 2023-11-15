using InsuranceSystem.Domain.Claims;
using InsuranceSystem.Domain.Expenses;
using InsuranceSystem.Domain.Policy;
using InsuranceSystem.Infrastructure.Claims;
using InsuranceSystem.Infrastructure.Expenses;
using InsuranceSystem.Infrastructure.Policy;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<PolicyHolder> PolicyHolders { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PolicyConfiguration().Configure(modelBuilder.Entity<PolicyHolder>());
            new ExpensesConfiguration().Configure(modelBuilder.Entity<Expense>());
            new ClaimsConfiguration().Configure(modelBuilder.Entity<Claim>());
        }
    }
}

