using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerlessSQLDemo.Customer;
using System;

[assembly: FunctionsStartup(typeof(ServerlessSQLDemo.Startup))]
namespace ServerlessSQLDemo
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DemoContext>(
                options => options.UseNpgsql(connectionString));

            builder.Services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
