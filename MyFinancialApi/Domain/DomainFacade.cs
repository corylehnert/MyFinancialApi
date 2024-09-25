using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;
namespace MyFinancialApi.Domain
{
    public static class DomainFacade
    {
        private static readonly SqlConnection _connection = new SqlConnection("");

        public static AddDebtResponse AddDebt(AddDebtRequest request)
        {
            var addDebtManager = new AddDebtManager(new AddDebtProvider(_connection));
            return addDebtManager.AddDebt(request);
        }

        public static FinancialReportResponse CreateFinancialReport()
        {
            var reportManager = new FinancialReportManager(new  FinancialReportProvider(_connection));
            return reportManager.CreateFinanicalReport();
        }

        public static FinancialReportResponse CreateWeeklyFinancialReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider(_connection));
            return reportManager.CreateWeeklyFinancialReport();
        }

        public static FinancialReportResponse CreateMonthlyFinancialiReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider(_connection));
            return reportManager.CreateMonthlyFinancialReport();
        }
    }
}
