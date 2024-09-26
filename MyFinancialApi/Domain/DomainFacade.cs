using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;
namespace MyFinancialApi.Domain
{
    public class DomainFacade : IDomainFacade
    {
        private readonly SqlConnection _connection = new SqlConnection("");

        public AddDebtResponse AddDebt(AddDebtRequest request)
        {
            var addDebtManager = new AddDebtManager(new AddDebtProvider(_connection));
            return addDebtManager.AddDebt(request);
        }

        public FinancialReportResponse CreateFinancialReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider(_connection));
            return reportManager.CreateFinanicalReport();
        }

        public FinancialReportResponse CreateWeeklyFinancialReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider(_connection));
            return reportManager.CreateWeeklyFinancialReport();
        }

        public FinancialReportResponse CreateMonthlyFinancialReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider(_connection));
            return reportManager.CreateMonthlyFinancialReport();
        }
    }
}
