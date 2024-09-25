using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain
{
    public static class DomainFacade
    {
        private static IAddDebtProvider addDebtProvider = new AddDebtProvider();
        private static AddDebtManager _addDebtManager = new AddDebtManager(addDebtProvider);
        private static IFinancialReportProvider _financialReportProvider = new FinancialReportProvider();
        private static FinancialReportManager _reportManager = new FinancialReportManager(_financialReportProvider);

        public static AddDebtResponse AddDebt(AddDebtRequest request)
        {
            return _addDebtManager.AddDebt(request);
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
