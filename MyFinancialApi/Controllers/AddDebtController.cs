using Microsoft.AspNetCore.Mvc;

namespace MyFinancialApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddDebtController : Controller
    {
        private readonly ILogger<AddDebtController> _logger;

        public AddDebtController(ILogger<AddDebtController> logger) 
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddDebt")]
        public IActionResult Post()
        {
            return new OkObjectResult("This is the AddDebt response.");
        }
    }
}
