using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Infrastructure.Persistent.Ef.siteEntity.Slider
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Domain.SiteEntities.Slider>
    {
        public void Configure(EntityTypeBuilder<Domain.SiteEntities.Slider> builder)
        {
            builder.ToTable("Sliders", "Slider")
                .HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.ImageName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.Link)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
