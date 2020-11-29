using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerlessSQLDemo.Customer
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> CreateAsync(CustomerViewModel vm);
        Task<IEnumerable<CustomerViewModel>> GetAsync();
        Task UpdateAsync(CustomerViewModel vm);
        Task DeleteAsync(CustomerViewModel vm);
    }
}
