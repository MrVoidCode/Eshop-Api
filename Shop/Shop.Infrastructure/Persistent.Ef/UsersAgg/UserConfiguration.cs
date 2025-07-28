using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UsersAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User")
                .HasKey(c => c.Id);
            builder.HasIndex(b => b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.Email).IsUnique();

            builder.Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired(false);
            builder.Property(c => c.Family)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(c => c.Avatar)
                .HasMaxLength(200)
                .IsRequired(false);
            builder.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsMany(f => f.Addresses, options =>
            {
                options.ToTable("Addresses", "User");
                options.HasKey(c => c.Id);

                options.Property(c => c.Name)
                    .HasMaxLength(40)
                    .IsRequired();
                options.Property(c => c.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                options.Property(c => c.PhoneNumber)
                    .HasMaxLength(11)
                    .IsRequired();
                options.Property(c => c.PostalCode)
                    .HasMaxLength(20)
                    .IsRequired();
                options.Property(c => c.City)
                    .IsRequired();
                options.Property(c => c.NationalCode)
                    .HasMaxLength(10)
                    .IsRequired();
                options.Property(c => c.Shire)
                    .HasMaxLength(50)
                    .IsRequired();
                options.Property(c => c.PostalAddress)
                    .HasMaxLength(200)
                    .IsRequired();
            });
            builder.OwnsMany(c => c.Roles)
                .ToTable("Roles", "User")
                .HasKey(c => c.Id);
            builder.OwnsMany(f => f.Wallets, options =>
            {
                options.ToTable("Wallets", "User")
                    .HasKey(c => c.Id);
                options.HasIndex(b => b.UserId);

                options.Property(c => c.Description)
                    .HasMaxLength(150)
                    .IsRequired(false);
            });
        }
    }
}
