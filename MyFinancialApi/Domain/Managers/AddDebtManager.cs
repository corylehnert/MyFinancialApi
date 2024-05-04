using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;

namespace MyFinancialApi.Domain.Managers
{
    public class AddDebtManager : IAddDebtManager
    {
        private AddDebtProvider _provider = new AddDebtProvider();

        public void AddDebt(AddDebtRequest request)
        {
            _provider.AddDebt(request);
        }
    }
}
