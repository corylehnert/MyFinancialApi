using Moq;
using MyFinancialApi.Domain.DTOs;
using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Responses;
namespace UnitTesting.Domain.Managers
{
    [TestClass]
    public class FinancialReportManagerTests
    {
        private static Mock<IFinancialReportProvider> _testProvider = new Mock<IFinancialReportProvider>();
        [TestMethod]
        public void FinancialReportManager_CreateFinancialReport_WhenValidRequestIsSent_ReturnFinancialReportResponse()
        {
            // Arrange
            _testProvider.Setup(m => m.CreateFinancialReport()).Returns(new FinancialReportResponse { Debts = new List<DebtEntry>
            {
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.MaxValue, DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-7), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-8), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddMonths(-3), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddYears(-2), DateTime.MinValue, "Tester")

            } 
            });
            var testManager = new FinancialReportManager(_testProvider.Object);

            // Act
            var result = testManager.CreateFinanicalReport();

            // Assert
            Assert.AreEqual(5, result.Debts.Count);
            Assert.AreEqual(0, result.Notices.Count);
        }

        [TestMethod]
        public void FinancialReportManager_CreateMonthlyReport_WhenValidRequestIsSent_ReturnFinancialReportResponse()
        {
            // Arrange
            _testProvider.Setup(m => m.CreateMonthlyFinancialReport()).Returns(new FinancialReportResponse { Debts = new List<DebtEntry>
            {
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.MaxValue, DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(7), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-8), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-25), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddMonths(-1), DateTime.MinValue, "Tester")

            }
            });
            var testManager = new FinancialReportManager(_testProvider.Object);

            // Act
            var result = testManager.CreateFinanicalReport();

            // Assert
            Assert.AreEqual(5, result.Debts.Count);
            Assert.AreEqual(0, result.Notices.Count);
        }

        [TestMethod]
        public void FinancialReportManager_CreateWeeklyReport_WhenValidRequestIsSent_ReturnFinancialReportResponse()
        {
            // Arrange
            _testProvider.Setup(m => m.CreateWeeklyFinanicalReport()).Returns(new FinancialReportResponse { Debts = new List<DebtEntry>
            {
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.MaxValue, DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-7), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-5), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-2), DateTime.MinValue, "Tester"),
                new DebtEntry(0, 100, "Test", DateTime.Now, "ONETIME", DateTime.Now.AddDays(-1), DateTime.MinValue, "Tester")

            }
            });
            var testManager = new FinancialReportManager(_testProvider.Object);

            // Act
            var result = testManager.CreateFinanicalReport();

            // Assert
            Assert.AreEqual(5, result.Debts.Count);
            Assert.AreEqual(0, result.Notices.Count);
        }
    }
}
