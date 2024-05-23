using MyFinancialApi.Domain.DTOs;

namespace MyFinancialApi.Web.DTOs.Responses
{
    public class FinancialReportResponse
    {
        public List<DebtEntry> Debts { get; set; } = new List<DebtEntry>();

        public List<string> Notices { get; set; }
    }
}
