using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.UserId);

            builder.OwnsOne(f => f.ShippingMethod, options =>
            {
                options.Property(c => c.ShippingTitle)
                    .HasMaxLength(100)
                    .IsRequired(false);
            });
            builder.OwnsOne(f => f.Discount, options =>
            {
                options.Property(c => c.Title)
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.OwnsOne(f => f.Address, options =>
            {
                options.ToTable("Addresses", "Order")
                    .HasKey(c => c.Id);
                options.HasIndex(c => c.UserId);
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
            builder.OwnsMany(f => f.Items, option =>
            {
                option.ToTable("Items", "Order")
                    .HasKey(c => c.Id);
                option.HasIndex(b => b.InventoryId);
                option.HasIndex(b => b.OrderId);
            });
        }
    }
}
