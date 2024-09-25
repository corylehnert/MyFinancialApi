using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;

namespace MyFinancialApi.Domain.Managers
{
    public class FinancialReportManager : IFinancialReportManager
    {
        private IFinancialReportProvider _provider;

        public FinancialReportManager(IFinancialReportProvider financialReportProvider)
        {
            _provider = financialReportProvider;
        }
        public FinancialReportResponse CreateFinanicalReport()
        {
            return _provider.CreateFinancialReport();
        }

        public FinancialReportResponse CreateWeeklyFinancialReport()
        {
            return _provider.CreateWeeklyFinanicalReport();
        }

        public FinancialReportResponse CreateMonthlyFinancialReport()
        {
            return _provider.CreateMonthlyFinancialReport();
        }
    }
}
