using Moq;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using Requests = MyFinancialApi.Web.DTOs.Requests;
using Responses = MyFinancialApi.Web.DTOs.Responses;

namespace UnitTesting.Domain.Managers
{
    [TestClass]
    public class AddDebtManagerTests
    {
        private Mock<IAddDebtProvider> mockProvider = new Mock<IAddDebtProvider>();
        [TestMethod]
        public void AddDebtManger_WhenRequestIsSent_ReturnsResponse()
        {
            
            mockProvider.Setup(m => m.AddDebt(It.IsAny<Requests.AddDebtRequest>())).Returns(new Responses.AddDebtResponse { Notices = new List<string> { "Debt added to database" } });
            var testRequest = new Requests.AddDebtRequest
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
