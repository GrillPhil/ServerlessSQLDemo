using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ServerlessSQLDemo.Customer
{
    public class GetCustomer
    {
        private readonly ICustomerService _customerService;

        public GetCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [FunctionName("GetCustomer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customers")] HttpRequest req,
            ILogger log)
        {
            var result = await _customerService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
