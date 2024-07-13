using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Managers
{
    public class FinancialReportManager : IFinancialReportManager
    {
        private FinancialReportProvider _provider = new FinancialReportProvider();

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
