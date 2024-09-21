using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Providers
{
    public interface IFinancialReportProvider
    {
        public FinancialReportResponse CreateFinancialReport();
        public FinancialReportResponse CreateWeeklyFinanicalReport();
        public FinancialReportResponse CreateMonthlyFinancialReport();
    }
}
