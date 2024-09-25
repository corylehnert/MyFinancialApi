using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;
namespace MyFinancialApi.Domain.Managers
{
    public class AddDebtManager : IAddDebtManager
    {
        private IAddDebtProvider _provider;

        public AddDebtManager(IAddDebtProvider provider)
        {
            _provider = provider;
        }

        public AddDebtResponse AddDebt(AddDebtRequest request)
        {
            return _provider.AddDebt(request);
        }
    }
}
