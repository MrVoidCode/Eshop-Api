using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CommentAgg;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments", "Comment");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Text)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}
