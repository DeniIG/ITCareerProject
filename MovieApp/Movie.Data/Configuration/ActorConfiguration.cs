using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Movies).WithOne(ma => ma.Actor).HasForeignKey(ma => ma.ActorId);
        }
    }
}
