using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Managers
{
    public abstract class IAddDebtManager
    {
        public abstract AddDebtResponse AddDebt(AddDebtRequest request);
    }
}
