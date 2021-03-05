using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DotNetSpa.Repository;
using DotNetSpa.Models;

namespace DotNetSpa.Function
{
  public class Customers
  {
    private readonly CustomersDbContext _context;
    public Customers(CustomersDbContext context)
    {
      _context = context;
    }


    [FunctionName("GetCustomers")]
    public static async Task<IActionResult> GetCustomers(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers")] HttpRequest req,
        ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");

      string name = req.Query["name"];

      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      dynamic data = JsonConvert.DeserializeObject(requestBody);
      name = name ?? data?.name;

      string responseMessage = string.IsNullOrEmpty(name)
          ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
          : $"Hello, {name}. This HTTP triggered function executed successfully.";

      return new OkObjectResult(responseMessage);
    }

    [FunctionName("PostCustomer")]
    public async Task<IActionResult> PostCustomer(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")] HttpRequest req,
            ILogger log)
    {
      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      Customer data = JsonConvert.DeserializeObject<Customer>(requestBody);

      var entity = await _context.AddAsync<Customer>(data);
      await _context.SaveChangesAsync();

      if (entity == null)
      {
        return new BadRequestObjectResult("Failed to save customer.");
      }

      return new OkObjectResult(JsonConvert.SerializeObject(entity.Entity));
    }
  }
}
