using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Infrastructure.Persistent.Ef.siteEntity.Banner
{
    internal class BannerConfiguration : IEntityTypeConfiguration<Domain.SiteEntities.Banner>
    {
        public void Configure(EntityTypeBuilder<Domain.SiteEntities.Banner> builder)
        {
            builder.ToTable("Banners", "Banner")
                .HasKey(c => c.Id);

            builder.Property(c => c.ImageName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.Link)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
