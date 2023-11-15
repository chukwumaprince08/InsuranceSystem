using InsuranceSystem.Common;
using InsuranceSystem.Domain.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceSystem.Infrastructure.Claims
{
    public class ClaimsConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                    .UseIdentityColumn();

            builder.Property(p => p.ClaimsId)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.NationalIDOfPolicyHolder)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.ExpenseId)
                  .IsRequired();

            builder.Property(p => p.Amount)
                 .IsRequired();

            builder.Property(p => p.DateOfExpense)
                 .IsRequired();

            builder.Property(p => p.ClaimsStatus)
                 .IsRequired()
                 .HasMaxLength(15);
                        

            builder.HasData(
                new Claim
                {
                    Id = 1,
                    NationalIDOfPolicyHolder = "NGN0024AA",
                    ClaimsId = "CLA001",
                    Amount = 20000,
                    DateOfExpense = new DateTime(2023, 02, 04),
                    ExpenseId = 1,
                    ClaimsStatus = ClaimsStatusEnums.Submitted.ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Claim
                {
                    Id = 2,
                    NationalIDOfPolicyHolder = "NGN0014AA",
                    ClaimsId = "CLA002",
                    Amount = 20000,
                    DateOfExpense = new DateTime(2023,02,04),
                    ExpenseId = 1,
                    ClaimsStatus = ClaimsStatusEnums.Submitted.ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });
        }
    }
}

