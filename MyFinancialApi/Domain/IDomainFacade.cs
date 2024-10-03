using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain
{
    public abstract class IDomainFacade
    {
        public AddDebtResponse AddDebt(AddDebtRequest request);

        public FinancialReportResponse CreateFinancialReport();

        public FinancialReportResponse CreateWeeklyFinancialReport();

        public FinancialReportResponse CreateMonthlyFinancialReport();
    }
}
