using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.DateRegistered).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
