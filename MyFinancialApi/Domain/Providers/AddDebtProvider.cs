using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace MyFinancialApi.Domain.Providers
{
    [ExcludeFromCodeCoverage]
    public class AddDebtProvider : IAddDebtProvider
    {
        private readonly DbConnection _debtDatabaseConnection = new SqlConnection("Data Source=localhost;Initial Catalog=DebtDatabase;Integrated Security=True;");
        public AddDebtProvider() 
        {
        }
        public override AddDebtResponse AddDebt(AddDebtRequest request)
        {
            var response = new AddDebtResponse();
            

            try
            {
                var query = $"INSERT INTO [dbo].[debt](Id, Description,Amount,DateCreated,Frequency,NextPaymentDate,LastPaymentDate,Owner) VALUES (@Id, @Description, @Amount, @DateCreated, @Frequency, @NextPaymentDate, @LastPaymentDate, @Owner)";

                var dbCommand = _debtDatabaseConnection.CreateCommand();
                dbCommand.CommandText = query;
                dbCommand.Parameters.Add(new SqlParameter("@Id", request.Id));
                dbCommand.Parameters.Add(new SqlParameter("@Description", request.Description));
                dbCommand.Parameters.Add(new SqlParameter("@Amount", request.Id));
                dbCommand.Parameters.Add(new SqlParameter("@DateCreated", request.DateOfOccurrence));
                dbCommand.Parameters.Add(new SqlParameter("@Frequency", request.Frequency));
                dbCommand.Parameters.Add(new SqlParameter("@NextPaymentDate", request.NextPaymentDate.ToShortDateString()));
                dbCommand.Parameters.Add(new SqlParameter("@LastPaymentDate", request.LastPaymentDate.ToShortDateString()));
                dbCommand.Parameters.Add(new SqlParameter("@Owner", request.Owner));
                _debtDatabaseConnection.Open();
                dbCommand.ExecuteNonQuery();
                response.Notices.Add("Debt added to database");
            }
            catch (SqlException ex)
            {
                response.Notices.Add($"Failed to Add Debt to Database; Exception thrown: {ex}");
            }
            finally
            {
                _debtDatabaseConnection.Close(); 
            }
            return response;
        }
    }
}
