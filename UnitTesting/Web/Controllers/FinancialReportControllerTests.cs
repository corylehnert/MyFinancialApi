using Microsoft.AspNetCore.Mvc;
using Moq;
using MyFinancialApi.Domain.DTOs;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.Controllers;
using MyFinancialApi.Web.DTOs.Responses;
using System.Net;

namespace UnitTesting.Web.Controllers
{
    [TestClass]
    public class FinancialReportControllerTests
    {
        [TestMethod]
        public void FinancialReportController_CreateFullReport_WhenValidRequestIsSent_ReturnsValidResponse()
        {
            // Arrange
            var mockManager = new Mock<IFinancialReportManager>();
            mockManager.Setup(m => m.CreateFinanicalReport()).Returns(CreateFullReportResponse());
            var testController = new FinancialReportController(mockManager.Object);
            // Act
            var result = testController.CreateFullReport() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType<FinancialReportResponse>(result.Value);
        }

        [TestMethod]
        public void FinancialReportController_CreateWeeklyFinancialReport_WhenValidRequestIsSent_ReturnsValidResponse()
        {
            // Arrange
            var mockManager = new Mock<IFinancialReportManager>();
            mockManager.Setup(m => m.CreateWeeklyFinancialReport()).Returns(CreateWeeklyReportResponse());
            var testController = new FinancialReportController(mockManager.Object);

            // Act
            var result = testController.CreateWeeklyReport() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType<FinancialReportResponse>(result.Value);
        }

        [TestMethod]
        public void FinancialReportController_CreateMonthlyFinancialReport_WhenValidRequestIsSent_ReturnsValidResponse()
        {
            // Arrange
            var mockManager = new Mock<IFinancialReportManager>();
            mockManager.Setup(m => m.CreateMonthlyFinancialReport()).Returns(CreateMonthlyReportResponse());
            var testController = new FinancialReportController(mockManager.Object);

            // Act
            var result = testController.CreateMonthlyReport() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType<FinancialReportResponse>(result.Value);
        }

        /// <summary>
        /// Create test response for retrieving a full report response
        /// </summary>
        /// <returns>Test response</returns>
        private FinancialReportResponse CreateFullReportResponse()
        {
            return new FinancialReportResponse
            {
                Debts = new List<DebtEntry>
                {
                    new DebtEntry
                    (
                        1,
                        100.00f,
                        "Test",
                        DateTime.Now,
                        "ONETIME",
                        DateTime.MaxValue,
                        DateTime.MinValue,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        2,
                        200.00f,
                        "Test",
                        DateTime.Now,
                        "WEEKLY",
                        DateTime.Now.AddDays(7),
                        DateTime.Now,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        3,
                        150.00f,
                        "Test",
                        DateTime.Now,
                        "ONETIME",
                        DateTime.MaxValue,
                        DateTime.MinValue,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        4,
                        50.00f,
                        "Test",
                        DateTime.Now,
                        "MONTHLY",
                        DateTime.Now.AddMonths(1),
                        DateTime.MinValue,
                        "Tester"
                    ),
                },
                Notices = new List<string>()
            };
        }

        /// <summary>
        /// Create test response for retrieving a weekly report response
        /// </summary>
        /// <returns>Test response</returns>
        private FinancialReportResponse CreateWeeklyReportResponse()
        {
            return new FinancialReportResponse
            {
                Debts = new List<DebtEntry>
                {
                    new DebtEntry
                    (
                        1,
                        100.00f,
                        "Test",
                        DateTime.Now,
                        "WEEKLY",
                        DateTime.Now.AddDays(7),
                        DateTime.Now,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        2,
                        200.00f,
                        "Test",
                        DateTime.Now.AddDays(3),
                        "WEEKLY",
                        DateTime.Now.AddDays(10),
                        DateTime.Now.AddDays(3),
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        3,
                        150.00f,
                        "Test",
                        DateTime.Now.AddDays(13),
                        "WEEKLY",
                        DateTime.Now.AddDays(20),
                        DateTime.Now.AddDays(13),
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        4,
                        50.00f,
                        "Test",
                        DateTime.Now.AddDays(15),
                        "WEEKLY",
                        DateTime.Now.AddDays(22),
                        DateTime.Now.AddDays(15),
                        "Tester"
                    ),
                },
                Notices = new List<string>()
            };
        }

        /// <summary>
        /// Create test response for retrieving a monthly report response
        /// </summary>
        /// <returns>Test response</returns>
        private FinancialReportResponse CreateMonthlyReportResponse()
        {
            return new FinancialReportResponse
            {
                Debts = new List<DebtEntry>
                {
                    new DebtEntry
                    (
                        1,
                        100.00f,
                        "Test",
                        DateTime.Now.AddDays(9),
                        "MONTHLY",
                        DateTime.Now.AddDays(9).AddMonths(1),
                        DateTime.Now.AddDays(9),
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        2,
                        200.00f,
                        "Test",
                        DateTime.Now,
                        "MONTHLY",
                        DateTime.Now.AddMonths(1),
                        DateTime.Now,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        3,
                        150.00f,
                        "Test",
                        DateTime.Now,
                        "MONTHLY",
                        DateTime.Now.AddMonths(1),
                        DateTime.Now,
                        "Tester"
                    ),
                    new DebtEntry
                    (
                        4,
                        50.00f,
                        "Test",
                        DateTime.Now,
                        "MONTHLY",
                        DateTime.Now.AddMonths(1),
                        DateTime.MinValue,
                        "Tester"
                    ),
                },
                Notices = new List<string>()
            };
        }

    }
}
