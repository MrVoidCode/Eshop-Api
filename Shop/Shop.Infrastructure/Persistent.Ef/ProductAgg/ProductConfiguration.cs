using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Product");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Slug).IsUnique();

            builder.Property(c => c.ImageName)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Slug)
                .IsRequired()
                .IsUnicode(false);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.OwnsOne(f => f.SeoData, options =>
            {
                options.Property(c => c.MetaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("MetaDescription");
                options.Property(c => c.MetaTitle)
                    .HasMaxLength(500)
                    .HasColumnName("MetaTitle");
                options.Property(c => c.MetaKeyWord)
                    .HasMaxLength(500)
                    .HasColumnName("MetaKeyWord");
                options.Property(c => c.IndexPage)
                    .HasMaxLength(500)
                    .HasColumnName("IndexPage");
                options.Property(c => c.Canonical)
                    .HasMaxLength(500)
                    .HasColumnName("Canonical");
                options.Property(c => c.Schema)
                    .HasMaxLength(500);
            });

            builder.OwnsMany(c => c.Images, options =>
            {
                options.ToTable("Images", "Product");
                options.HasKey(c => c.Id);
                options.Property(c => c.ImageName)
                    .HasMaxLength(500);
            });
            builder.OwnsMany(c => c.Specifications, options =>
            {
                options.ToTable("Images", "Product");
                options.HasKey(c => c.Id);
                options.Property(c => c.Key)
                    .HasMaxLength(50);
                options.Property(c => c.Value)
                    .HasMaxLength(50);
            });

        }
    }
}
