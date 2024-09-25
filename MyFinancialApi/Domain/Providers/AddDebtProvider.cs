using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyFinancialApi.Domain.Providers
{
    public class AddDebtProvider : IAddDebtProvider
    {
        private readonly SqlConnection _debtDatabaseConnection;
        public AddDebtProvider(SqlConnection debtDatabaseConnection) 
        {
            _debtDatabaseConnection = debtDatabaseConnection;
        }
        public AddDebtResponse AddDebt(AddDebtRequest request)
        {
            var response = new AddDebtResponse();
            

            try
            {
                var query = $"INSERT INTO [dbo].[debt](Id, Description,Amount,DateCreated,Frequency,NextPaymentDate,LastPaymentDate,Owner) VALUES (@Id, @Description, @Amount, @DateCreated, @Frequency, @NextPaymentDate, @LastPaymentDate, @Owner)";

                var dbCommand = _debtDatabaseConnection.CreateCommand();
                dbCommand.CommandText = query;
                dbCommand.Parameters.AddWithValue("@Id", request.Id);
                dbCommand.Parameters.AddWithValue("@Description", request.Description);
                dbCommand.Parameters.AddWithValue("@Amount", request.Amount);
                dbCommand.Parameters.AddWithValue("@DateCreated", request.DateOfOccurrence);
                dbCommand.Parameters.AddWithValue("@Frequency", request.Frequency);
                dbCommand.Parameters.AddWithValue("@NextPaymentDate", request.NextPaymentDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@LastPaymentDate", request.LastPaymentDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@Owner", request.Owner);
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
