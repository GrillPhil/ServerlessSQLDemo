using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessSQLDemo.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly DemoContext _context;

        public CustomerService(DemoContext context)
        {
            _context = context;
        }

        public async Task<CustomerViewModel> CreateAsync(CustomerViewModel vm)
        {
            var customer = new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                Address = vm.Address,
                City = vm.City,
                PostalCode = vm.PostalCode
            };

            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return new CustomerViewModel()
            {
                Address = result.Entity.Address,
                PostalCode = result.Entity.PostalCode,
                City = result.Entity.City,
                Id = result.Entity.Id,
                Name = result.Entity.Name
            };
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAsync()
        {
            var entities = await _context.Customers.ToListAsync();

            return entities.Select(e => new CustomerViewModel()
            {
                Id = e.Id,
                Address = e.Address,
                City = e.City,
                Name = e.Name,
                PostalCode = e.PostalCode
            });
        }

        public async Task UpdateAsync(CustomerViewModel vm)
        {
            var entity = _context.Customers.FirstOrDefault(item => item.Id == vm.Id);

            if (entity != null)
            {
                entity.Address = vm.Address;
                entity.City = vm.City;
                entity.Name = vm.Name;
                entity.PostalCode = vm.PostalCode;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(CustomerViewModel vm)
        {
            var entity = _context.Customers.FirstOrDefault(item => item.Id == vm.Id);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }
    }
}
