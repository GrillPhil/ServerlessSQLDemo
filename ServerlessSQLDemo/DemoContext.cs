using Microsoft.EntityFrameworkCore;
using ServerlessSQLDemo.Customer;

namespace ServerlessSQLDemo
{
    public class DemoContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
    }
}
