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
    private readonly ICustomersRepository _CustomersRepository;
    public Customers(CustomersDbContext context, ICustomersRepository repository)
    {
      _CustomersRepository = repository;
    }


    [FunctionName("GetCustomers")]
    public async Task<IActionResult> GetCustomers(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers")] HttpRequest req,
        ILogger log)
    {
      try
      {
        var customers = await _CustomersRepository.GetCustomersAsync();
        return new OkObjectResult(customers);
      }
      catch (Exception exp)
      {
        log.LogError(exp.Message);
        return new BadRequestObjectResult(exp);
      }
    }

    [FunctionName("PostCustomer")]
    public async Task<IActionResult> PostCustomer(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")] HttpRequest req,
            ILogger log)
    {
      try
      {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        Customer customer = JsonConvert.DeserializeObject<Customer>(requestBody);
        var newCustomer = await _CustomersRepository.InsertCustomerAsync(customer);

        if (newCustomer == null)
        {
          return new BadRequestResult();
        }
        return new OkObjectResult(JsonConvert.SerializeObject(newCustomer));
      }
      catch (Exception exp)
      {
        log.LogError(exp.Message);
        return new BadRequestObjectResult(exp);
      }
    }
  }
}
