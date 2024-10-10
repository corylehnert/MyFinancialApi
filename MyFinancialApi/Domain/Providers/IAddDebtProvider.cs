using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Providers
{
    public abstract class IAddDebtProvider
    {
        public abstract AddDebtResponse AddDebt(AddDebtRequest request);
    }
}
