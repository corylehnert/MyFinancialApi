using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Web.Controllers
{
    [ApiController]
    
    public class AddDebtController : Controller
    {
        private readonly ILogger<AddDebtController> _logger;

        public AddDebtController(ILogger<AddDebtController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("AddDebt")]
        public IActionResult Post(AddDebtRequest request)
        {
            var response = new AddDebtResponse();
            try
            {
                response = DomainFacade.AddDebt(request);
            }
            catch (Exception ex) 
            {
                response.Notices.Add(ex.Message);
                return new BadRequestObjectResult(response);
            }
            return new OkObjectResult(response);
        }
    }
}
