using DotNetSpa.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DotNetSpa
{
  public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersDbContext>
  {
    public CustomersDbContext CreateDbContext(string[] args)
    {

      var config = new ConfigurationBuilder()
          .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables()
          .Build();

      // Get connection string from config
      var connectionString = config.GetValue<string>("SqlConnectionString");

      var optionsBuilder = new DbContextOptionsBuilder<CustomersDbContext>();

      optionsBuilder.UseSqlServer(connectionString);

      return new CustomersDbContext(optionsBuilder.Options);
    }
  }
}


