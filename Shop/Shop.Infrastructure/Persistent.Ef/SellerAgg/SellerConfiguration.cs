using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "Seller")
                .HasKey(c => c.Id);
            builder.HasIndex(b => b.NationalCode).IsUnique();

            builder.Property(c => c.ShopName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.NationalCode)
                .HasMaxLength(10)
                .IsRequired();

            builder.OwnsMany(c => c.SellerInventoryItems, options =>
            {
                options.ToTable("Inventories", "Seller");
                options.HasKey(c => c.Id);
                options.HasIndex(b => b.ProductId);
                options.HasIndex(b => b.SellerId);

            });

        }
    }
}
