using Moq;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Domain.Managers
{
    [TestClass]
    public class AddDebtManagerTests
    {
        [TestMethod]
        public void AddDebtManger_WhenRequestIsSent_ReturnsResponse()
        {
            var mockProvider = new Mock<AddDebtProvider>();
            mockProvider.Setup(m => m.AddDebt(It.IsAny<AddDebtRequest>())).Returns(new MyFinancialApi.Web.DTOs.Responses.AddDebtResponse { Notices = new List<string> { "Debt added to database" } });
            var testRequest = new AddDebtRequest
            {
                Id = 0,
                Description = "Test",
                Amount = 100,
                DateOfOccurrence = DateTime.Now,
                LastPaymentDate = DateTime.MinValue,
                NextPaymentDate = DateTime.MaxValue,
                Frequency = "ONETIME",
                Owner = "Tester"
            };
            var testManager = new AddDebtManager(mockProvider.Object);

            // Act
            var result = testManager.AddDebt(testRequest);

            // Assert
            Assert.IsTrue(result.Notices.Count() == 1);
            Assert.IsTrue(result.Notices.Contains("Debt added to database"));

        }
    }
}
