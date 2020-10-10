using Codeizi.Application.ComplexExample.Customers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Codeizi.Service.API.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        public async Task<IActionResult> Post(CustomerViewModel customerViewModel)
        {
            return await Task.FromResult<IActionResult>(Ok(customerViewModel));
        }
    }
}