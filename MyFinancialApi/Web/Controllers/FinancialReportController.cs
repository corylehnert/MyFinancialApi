using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;

namespace MyFinancialApi.Web.Controllers
{
    [ApiController]
    public class FinancialReportController : Controller
    {
        private readonly ILogger<FinancialReportController> _logger;
        private readonly IDomainFacade _domainFacade; 
        public FinancialReportController(ILogger<FinancialReportController> logger, IDomainFacade domainFacade)
        {
            _logger = logger;
            _domainFacade = domainFacade;
        }

        [HttpGet]
        [Route("FullReport")]
        public IActionResult CreateFullReport()
        {
            var domainFacade = new DomainFacade();
            var response = domainFacade.CreateFinancialReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("WeeklyReport")]
        public IActionResult CreateWeeklyReport()
        {
            var domainFacade = new DomainFacade();
            var response = domainFacade.CreateWeeklyFinancialReport();
            return Ok(response);
        }

        [HttpGet]
        [Route("MonthlyReport")]
        public IActionResult CreateMonthlyReport()
        {
            var domainFacade = new DomainFacade();
            var response = domainFacade.CreateMonthlyFinancialiReport();
            return Ok(response);
        }
    }
}
