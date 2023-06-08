using System;
using ApiDogs.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDogs.DAL;

public class DogsContext : DbContext
{

	public DbSet<Dog> Dog { get; set; }

	public DogsContext(DbContextOptions<DogsContext> options)
		:base(options)
	{ 
	}

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}

