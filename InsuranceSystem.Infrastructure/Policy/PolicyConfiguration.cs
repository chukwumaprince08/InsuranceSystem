using System;
using InsuranceSystem.Domain.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsuranceSystem.Infrastructure.Policy
{
    public class PolicyConfiguration : IEntityTypeConfiguration<PolicyHolder>
    {
        public void Configure(EntityTypeBuilder<PolicyHolder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                    .UseIdentityColumn();

            builder.Property(p => p.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.NationalIDNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.PolicyNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.DateOfBirth)
                   .IsRequired();

            builder.HasData(
                new PolicyHolder
                {
                    Id = 1,
                    Name = "Precious",
                    Surname = "Chukwuma",
                    NationalIDNumber = "NGN0014AA",
                    PolicyNumber = "H2441",
                    DateOfBirth = new DateTime(2000, 06, 05),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new PolicyHolder
                {
                    Id = 2,
                    Name = "Gladys",
                    Surname = "Chukwuma",
                    NationalIDNumber = "NGN0024AA",
                    PolicyNumber = "H2442",
                    DateOfBirth = new DateTime(2001, 06, 05),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
                );
        }
    }
}

