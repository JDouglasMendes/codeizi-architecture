using Codeizi.Application.ComplexExample.Customers.Contracts;
using Codeizi.Application.ComplexExample.Customers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Codeizi.Service.API.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        public async Task<IActionResult> Post(CustomerViewModel customerViewModel)
            => ModelState.IsValid ?
                  CustomResponse(await customerAppService.Register(customerViewModel)) :
                  CustomResponse(ModelState);
    }
}