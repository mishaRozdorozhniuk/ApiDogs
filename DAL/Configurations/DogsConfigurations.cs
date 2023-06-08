using System;
using ApiDogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;

namespace ApiDogs.DAL.Configurations;

public class DogsConfigurations : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasKey(x => x.Gid);
        builder.Property(x => x.Name).HasMaxLength(15);
        builder.Property(x => x.Color).HasMaxLength(15);
    }
}

