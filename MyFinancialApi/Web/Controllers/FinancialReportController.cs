using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

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
        public IActionResult CreateFullReport()
        {
            var response = DomainFacade.CreateFinancialReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("WeeklyReport")]
        public IActionResult CreateWeeklyReport()
        {
            var response = DomainFacade.CreateWeeklyFinancialReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("MonthlyReport")]
        public IActionResult CreateMonthlyReport()
        {
            var response = new FinancialReportResponse();
            return Ok(response);
        }
    }
}
