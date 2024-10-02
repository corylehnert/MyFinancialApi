using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Managers
{
    public abstract class IFinancialReportManager
    {
        public abstract FinancialReportResponse CreateFinanicalReport();
        public abstract FinancialReportResponse CreateWeeklyFinancialReport();
        public abstract FinancialReportResponse CreateMonthlyFinancialReport();
    }
}
