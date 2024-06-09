using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;

namespace MyFinancialApi.Web.Controllers
{
    [ApiController]
    public class FinancialReportController : Controller
    {
        private readonly ILogger<FinancialReportController> _logger;

        public FinancialReportController(ILogger<FinancialReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("FullReport")]
        public IActionResult Get()
        {
            var response = DomainFacade.CreateFinancialReport();
            return Ok(response);
        }
    }
}
