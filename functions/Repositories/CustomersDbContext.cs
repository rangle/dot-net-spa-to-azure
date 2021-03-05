using System;
using DotNetSpa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotNetSpa.Repository
{
  public class CustomersDbContext : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<State> States { get; set; }

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }


  }

  public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersDbContext>
  {
    public CustomersDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<CustomersDbContext>();
      optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

      return new CustomersDbContext(optionsBuilder.Options);
    }
  }
}