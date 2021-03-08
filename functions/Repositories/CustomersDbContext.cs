using DotNetSpa.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetSpa.Repository
{
  public class CustomersDbContext : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }
  }
}