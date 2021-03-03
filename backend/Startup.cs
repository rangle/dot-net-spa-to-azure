﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Angular_Net_Spa.Repository;
using Microsoft.Extensions.Hosting;

namespace Angular_Net_Spa
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //Add PostgreSQL support
      //services.AddDbContext<CustomersDbContext>(options => {
      //    options.UseNpgsql(Configuration.GetConnectionString("CustomersPostgresConnectionString"));
      //});

      //Add SQL Server support
      //services.AddDbContext<CustomersDbContext>(options => {
      //    options.UseSqlServer(Configuration.GetConnectionString("CustomersSqlServerConnectionString"));
      //});

      //Add SqLite support
      services.AddDbContext<CustomersDbContext>(options =>
      {
        options.UseSqlite(Configuration.GetConnectionString("CustomersSqliteConnectionString"));
      });

      // This method will not register services used for views or pages.
      services.AddControllers();

      // Handle XSRF Name for Header
      services.AddAntiforgery(options =>
      {
        options.HeaderName = "X-XSRF-TOKEN";
      });

      services.AddCors(o => o.AddPolicy("AllowAllPolicy", options =>
      {
        options.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithExposedHeaders("X-InlineCount");
      }));

      services.AddCors(o => o.AddPolicy("AllowSpecific", options =>
              options.WithOrigins("http://localhost:4200")
                     .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                     .WithHeaders("accept", "content-type", "origin", "X-InlineCount")
                     .WithExposedHeaders("X-InlineCount")));

      services.AddScoped<ICustomersRepository, CustomersRepository>();
      services.AddScoped<IStatesRepository, StatesRepository>();
      services.AddTransient<CustomersDbSeeder>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
        IWebHostEnvironment env,
        CustomersDbSeeder customersDbSeeder,
        IAntiforgery antiforgery)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // This would need to be locked down as needed (very open right now)
      app.UseCors("AllowAllPolicy");
      app.UseHttpsRedirection();

      // Manually handle setting XSRF cookie. Needed because HttpOnly 
      // has to be set to false so that Angular is able to read/access the cookie.
      app.Use((context, next) =>
      {
        string path = context.Request.Path.Value;
        if (path != null && !path.ToLower().Contains("/api"))
        {
          var tokens = antiforgery.GetAndStoreTokens(context);
          context.Response.Cookies.Append("XSRF-TOKEN",
                    tokens.RequestToken, new CookieOptions { HttpOnly = false }
                );
        }

        return next();
      });

      // For 3.0
      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();

        endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action}/{id?}");
      });


      customersDbSeeder.SeedAsync(app.ApplicationServices).Wait();
    }
  }
}