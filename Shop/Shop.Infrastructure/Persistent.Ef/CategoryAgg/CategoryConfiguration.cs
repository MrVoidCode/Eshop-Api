using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Category");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Slug).IsUnique();

            builder.Property(c => c.Slug)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);

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
                    .HasMaxLength(500)
                    .HasColumnName("Schema");
            });
            builder.HasMany(f => f.Child)
                .WithOne()
                .HasForeignKey(b => b.ProductId);
        }
    }
}
