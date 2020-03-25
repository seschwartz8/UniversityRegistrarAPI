using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UniversityRegistrar.Models;

namespace UniversityRegistrar
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      //First listed in configureservices
      services.AddControllers();

      services.AddDbContext<UniversityRegistrarContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DevConnection")));

      services.AddCors();

      // services.Configure<IdentityOptions>(options =>
      // {
      //   options.Password.RequireDigit = false;
      //   options.Password.RequiredLength = 0;
      //   options.Password.RequireLowercase = false;
      //   options.Password.RequireNonAlphanumeric = false;
      //   options.Password.RequireUppercase = false;
      //   options.Password.RequiredUniqueChars = 0;
      // });
    }

    public void Configure(IApplicationBuilder app, , IWebHostIHostingEnvironment env)
    {
      app.UseCors(options =>
        options.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}