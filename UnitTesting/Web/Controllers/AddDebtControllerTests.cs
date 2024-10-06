using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.Controllers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Net;

namespace UnitTesting.Web.Controllers
{
    [TestClass]
    public class AddDebtControllerTests
    {
        private AddDebtController? testController;

        [TestMethod]
        public void AddDebtController_WhenValidRequestIsSent_ReturnValidResponse()
        {
            // Arrange
            var mockManager = new Mock<IAddDebtManager>();
            var mockLogger = new Mock<Logger<AddDebtController>>();
            mockManager.Setup(m => m.AddDebt(It.IsAny<AddDebtRequest>())).Returns(new AddDebtResponse {  Notices = new List<string> { "Debt added to database" } });
            testController = new AddDebtController(mockManager.Object);

            // Act
            var result = testController.Post(new AddDebtRequest());
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.IsInstanceOfType<AddDebtResponse>(okResult.Value);
        }
    }
}
