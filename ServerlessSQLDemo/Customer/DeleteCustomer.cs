using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ServerlessSQLDemo.Customer
{
    public class DeleteCustomer
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [FunctionName("DeleteCustomer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "customers")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<CustomerViewModel>(requestBody);

            await _customerService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
