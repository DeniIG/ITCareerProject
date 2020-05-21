using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Configuration
{
    class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Movies).WithOne(md => md.Director).HasForeignKey(md => md.Id);
        }
    }
}
