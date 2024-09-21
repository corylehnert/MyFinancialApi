using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;

namespace MyFinancialApi.Domain.Managers
{
    public class AddDebtManager : IAddDebtManager
    {
        private IAddDebtProvider _provider;

        public AddDebtManager(IAddDebtProvider provider)
        {
            _provider = provider
        }
        public void AddDebt(AddDebtRequest request)
        {
            _provider.AddDebt(request);
        }
    }
}
