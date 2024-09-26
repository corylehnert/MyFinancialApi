using Moq;
using Moq.Protected;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Domain.Providers
{
    [TestClass]
    public class AddDebtProviderTests
    {
        [TestMethod]
        public void AddDebtProvider_WhenRequestIsPassed_SucceedNoticeIsCreated()
        {
            // Arrange
            //var mockSqlCommand = new Mock<SqlCommand>();
            //mockSqlCommand.Setup(x => x.ExecuteNonQuery()).Returns(1);
            //var mockSqlConnection = new Mock<DbConnection>();
            //mockSqlConnection.Protected().Setup<DbCommand>("CreateDbCommand").Returns(mockSqlCommand.Object);

            //var testProvider = new AddDebtProvider(mockSqlConnection.Object);

            //var testRequest = new AddDebtRequest
            //{
            //    Id = 0,
            //    Description = "Test",
            //    Amount = 100,
            //    DateOfOccurrence = DateTime.Now,
            //    LastPaymentDate = DateTime.MinValue,
            //    NextPaymentDate = DateTime.MaxValue,
            //    Frequency = "ONETIME",
            //    Owner = "Tester"
            //};

            // Act
            // var result = testProvider.AddDebt(testRequest);

            // Assert
            //Assert.AreEqual(1, result.Notices.Count);
            //Assert.IsTrue(result.Notices.Contains("Debt added to database."));
        }
    }
}
