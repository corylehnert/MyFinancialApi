using Microsoft.AspNetCore.Mvc;

namespace MyFinancialApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportController : Controller
    {
        private readonly ILogger<FinancialReportController> _logger;

        public FinancialReportController(ILogger<FinancialReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Report")]
        public IActionResult Get()
        {
            return new OkObjectResult("This is the Report response.");
        }
    }
}
