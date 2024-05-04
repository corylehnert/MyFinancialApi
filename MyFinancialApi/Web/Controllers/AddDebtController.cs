﻿using Microsoft.AspNetCore.Mvc;
using MyFinancialApi.Domain;
using MyFinancialApi.Web.DTOs.Requests;

namespace MyFinancialApi.Web.Controllers
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
        public IActionResult Post(AddDebtRequest request)
        {
            try
            {
                DomainFacade.AddDebt(request);
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
            return new OkObjectResult("This is the AddDebt response with no errors.");
        }
    }
}
