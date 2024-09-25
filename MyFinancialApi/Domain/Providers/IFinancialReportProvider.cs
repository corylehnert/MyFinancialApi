using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Providers
{
    public abstract class IFinancialReportProvider
    {
        public abstract FinancialReportResponse CreateFinancialReport();
        public abstract FinancialReportResponse CreateWeeklyFinanicalReport();
        public abstract FinancialReportResponse CreateMonthlyFinancialReport();
    }
}
