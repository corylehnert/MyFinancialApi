using MyFinancialApi.Domain.Providers;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;
namespace MyFinancialApi.Domain.Managers
{
    public class AddDebtManager : IAddDebtManager
    {
        private AddDebtProvider _provider = new AddDebtProvider(new SqlConnection(""));

        public AddDebtResponse AddDebt(AddDebtRequest request)
        {
            return _provider.AddDebt(request);
        }
    }
}
