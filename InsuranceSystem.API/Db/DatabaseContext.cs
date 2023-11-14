using System;
using InsuranceSystem.Domain.Policy;
using InsuranceSystem.Infrastructure.Policy;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.API.Db
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<PolicyHolder> PolicyHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			
			new PolicyConfiguration().Configure(modelBuilder.Entity<PolicyHolder>());
        }
    }
}

