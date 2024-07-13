using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain
{
    public static class DomainFacade
    {
        private static AddDebtManager _addDebtManager = new AddDebtManager();
        private static FinancialReportManager _reportManager = new FinancialReportManager();

        public static void AddDebt(AddDebtRequest request)
        {
            _addDebtManager.AddDebt(request);
        }

        public static FinancialReportResponse CreateFinancialReport()
        {
            return _reportManager.CreateFinanicalReport();
        }

        public static FinancialReportResponse CreateWeeklyFinancialReport()
        {
            return _reportManager.CreateWeeklyFinancialReport();
        }

        public static FinancialReportResponse CreateMonthlyFinancialiReport()
        {
            return _reportManager.CreateMonthlyFinancialReport();
        }
    }
}
