using MyFinancialApi.Domain.Managers;
using MyFinancialApi.Web.DTOs.Requests;

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

        public static void CreateFinancialReport()
        {
            throw new NotImplementedException();
        }
    }
}
