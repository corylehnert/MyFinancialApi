using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;

namespace MyFinancialApi.Web.Controllers
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
        public IActionResult Get(FinancialReportRequest request)
        {
            var response = DomainFacade.CreateFinancialReport(request);
            return Ok(response);
        }
    }
}
