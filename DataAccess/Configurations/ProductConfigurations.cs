using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Property configurations
            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Genre)
                   .HasMaxLength(300)
                   .IsRequired();
        }
    }
}
