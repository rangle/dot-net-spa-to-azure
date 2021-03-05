using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using DotNetSpa.Repository;

[assembly: FunctionsStartup(typeof(DotNetSpa.Startup))]

namespace DotNetSpa
{
  class Startup : FunctionsStartup
  {
    // Register services to use for dependency injection
    // https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
    public override void Configure(IFunctionsHostBuilder builder)
    {
      string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
      builder.Services.AddDbContext<CustomersDbContext>(
          options => options.UseSqlServer(SqlConnection));
    }
  }
}
