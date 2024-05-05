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

        public static FinancialReportResponse CreateFinancialReport(FinancialReportRequest request)
        {
            return _reportManager.CreateFinanicalReport(request);
        }
    }
}
