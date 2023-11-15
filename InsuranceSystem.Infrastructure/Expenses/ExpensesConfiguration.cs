using System;
using InsuranceSystem.Domain.Expenses;
using InsuranceSystem.Domain.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceSystem.Infrastructure.Expenses
{
    public class ExpensesConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                    .UseIdentityColumn();

            builder.Property(p => p.ExpenseType)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.ExpenseDescription)
                   .IsRequired()
                   .HasMaxLength(150);


            builder.HasData(
                new Expense
                {
                    Id = 1,
                    ExpenseType = "Procedure",
                    ExpenseDescription = "D and C",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Expense
                {
                    Id = 2,
                    ExpenseType = "Prescription",
                    ExpenseDescription = "Typhoid and Malaria Parasite Injection",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });
        }
    }
}

