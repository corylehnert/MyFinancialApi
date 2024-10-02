using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Domain.Managers;

namespace MyFinancialApi.Web.Controllers
{
    [ApiController]
    public class FinancialReportController : Controller
    {
        private readonly ILogger<FinancialReportController> _logger;
        private readonly IFinancialReportManager _manager;
        public FinancialReportController(ILogger<FinancialReportController> logger, IFinancialReportManager financialReportManager)
        {
            _logger = logger;
            _manager = financialReportManager;
        }

        [HttpGet]
        [Route("FullReport")]
        public IActionResult CreateFullReport()
        {
            var response = _manager.CreateFinanicalReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("WeeklyReport")]
        public IActionResult CreateWeeklyReport()
        {
            var response = _manager.CreateWeeklyFinancialReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("MonthlyReport")]
        public IActionResult CreateMonthlyReport()
        {
            var response = _manager.CreateMonthlyFinancialReport();
            return Ok(response);
        }
    }
}
