using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;

namespace MyFinancialApi.Domain.Managers
{
    public class AddDebtManager : IAddDebtManager
    {
        private AddDebtProvider _provider = new AddDebtProvider();

        public AddDebtResponse AddDebt(AddDebtRequest request)
        {
            return _provider.AddDebt(request);
        }
    }
}
