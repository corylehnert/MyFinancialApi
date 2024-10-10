using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Web.Controllers
{
    [ApiController]
    
    public class AddDebtController : Controller
    {
        private readonly IAddDebtManager _manager;

        public AddDebtController(IAddDebtManager addDebtManager)
        {
            _manager = addDebtManager;
        }

        [HttpPost]
        [Route("AddDebt")]
        public IActionResult Post(AddDebtRequest request)
        {
            var response = new AddDebtResponse();
            try
            {
                response = _manager.AddDebt(request);
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
