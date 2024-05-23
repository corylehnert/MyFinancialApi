using MyFinancialApi.Domain.DTOs;
using MyFinancialApi.Web.DTOs.Requests;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data.SqlClient;

namespace MyFinancialApi.Domain.Providers
{
    public class FinancialReportProvider
    {
        public FinancialReportResponse CreateFinancialReport()
        {
            var response = new FinancialReportResponse();

            var debtDatabaseConnection = new SqlConnection("");
            try
            {
                var query = $"SELECT * FROM [dbo].[debt]";
                var sqlCommand = new SqlCommand(query, debtDatabaseConnection);
                debtDatabaseConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var debt = ConvertDatabaseEntryToDebt(reader);
                        response.Debts.Add(debt);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Notices.Add("Error during process: " + ex.Message);
            }
            finally
            {
                debtDatabaseConnection.Close();
            }
            return response;
        }

        /// <summary>
        /// Convert database entry to the actual object it represents
        /// </summary>
        /// <param name="dbEntry">the data base reader with the current entry loaded</param>
        /// <returns>a <see cref="Debt"/> object </returns>
        private DebtEntry ConvertDatabaseEntryToDebt(SqlDataReader dbEntry)
        {
            var id = Int32.Parse(dbEntry[0].ToString());
            var description = dbEntry[2].ToString();
            var amount = decimal.Parse(dbEntry[1].ToString()).ToString("0.00");
            var dateCreated = DateTime.Parse(dbEntry[3].ToString());
            var frequency = dbEntry[4].ToString();
            var nextPaymentDate = DateTime.Parse(dbEntry[5].ToString());
            var lastPaymentDate = DateTime.Parse(dbEntry[6].ToString());
            var owner = dbEntry[7].ToString();

            return new DebtEntry(id, float.Parse(amount), description, dateCreated, frequency, nextPaymentDate, lastPaymentDate, owner);
        }
    }
}
