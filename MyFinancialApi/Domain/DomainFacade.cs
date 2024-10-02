using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;
namespace MyFinancialApi.Domain
{
    public  class DomainFacade : IDomainFacade
    {
        private readonly SqlConnection _connection = new SqlConnection("http://localhost:5000/");
        public DomainFacade()
        {

        }

        public  AddDebtResponse AddDebt(AddDebtRequest request)
        {
            var addDebtManager = new AddDebtManager(new AddDebtProvider());
            return addDebtManager.AddDebt(request);
        }

        public  FinancialReportResponse CreateFinancialReport()
        {
            var reportManager = new FinancialReportManager(new  FinancialReportProvider());
            return reportManager.CreateFinanicalReport();
        }

        public  FinancialReportResponse CreateWeeklyFinancialReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider());
            return reportManager.CreateWeeklyFinancialReport();
        }

        public  FinancialReportResponse CreateMonthlyFinancialiReport()
        {
            var reportManager = new FinancialReportManager(new FinancialReportProvider());
            return reportManager.CreateMonthlyFinancialReport();
        }
    }
}
