using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Providers
{
    public class FinancialReportProvider
    {
        public FinancialReportResponse CreateFinancialReport(FinancialReportRequest request)
        {
            var response = new FinancialReportResponse();
            return response;
        }
    }
}
