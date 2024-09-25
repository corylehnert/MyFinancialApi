using MyFinancialApi.Domain.DTOs;
using MyFinancialApi.Web.DTOs.Responses;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyFinancialApi.Domain.Providers
{
    
    public class FinancialReportProvider
    {
        private readonly Func<DbConnection> _debtDatabaseConnection;
        
        public FinancialReportProvider(Func<DbConnection> debtDatabaseConnection)
        {
            _debtDatabaseConnection = debtDatabaseConnection; 
        }
        public FinancialReportResponse CreateFinancialReport()
        {
            var response = new FinancialReportResponse();

            try
            {
                using (var connection = _debtDatabaseConnection.Invoke())
                {
                    var query = $"SELECT * FROM [dbo].[debt]";
                    var sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = query;
                    connection.Open();

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var debt = ConvertDatabaseEntryToDebt(reader);
                            response.Debts.Add(debt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Notices.Add("Error during process: " + ex.Message);
            }
            return response;
        }

        public FinancialReportResponse CreateWeeklyFinanicalReport()
        {
            var response = new FinancialReportResponse();

            
            try
            {
                using(var connection = _debtDatabaseConnection.Invoke())
                {
                    var query = $"SELECT * FROM [dbo].[debt] where DateCreated between DATEADD(week, -1, GETDATE()) and GETDATE()";
                    var sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = query;

                    connection.Open();

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var debt = ConvertDatabaseEntryToDebt(reader);
                            response.Debts.Add(debt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Notices.Add("Error during process: " + ex.Message);
            }
            return response;
        }

        public FinancialReportResponse CreateMonthlyFinancialReport()
        {
            var response = new FinancialReportResponse();


            try
            {
               using(var connection = _debtDatabaseConnection.Invoke())
                {
                    var query = $"SELECT * FROM [dbo].[debt] where DateCreated between DATEADD(month, -1, GETDATE()) and GETDATE()";
                    var sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = query;
                    connection.Open();

                    using (IDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var debt = ConvertDatabaseEntryToDebt(reader);
                            response.Debts.Add(debt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Notices.Add("Error during process: " + ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Convert database entry to the actual object it represents
        /// </summary>
        /// <param name="dbEntry">the data base reader with the current entry loaded</param>
        /// <returns>a <see cref="Debt"/> object </returns>
        private DebtEntry ConvertDatabaseEntryToDebt(IDataReader dbEntry)
        {
            var id = dbEntry.GetInt32(dbEntry.GetOrdinal("ID"));
            var description = dbEntry.GetString(dbEntry.GetOrdinal("Description"));
            var amount = dbEntry.GetDecimal(dbEntry.GetOrdinal("Amount")).ToString("0.00");
            var dateCreated = dbEntry.GetDateTime(dbEntry.GetOrdinal("DateCreated"));
            var frequency = dbEntry.GetString(dbEntry.GetOrdinal("Frequency"));
            var nextPaymentDate = dbEntry.GetString(dbEntry.GetOrdinal("NextPaymentDate"));
            var lastPaymentDate = dbEntry.GetString(dbEntry.GetOrdinal("LastPaymentDate"));
            var owner = dbEntry.GetString(dbEntry.GetOrdinal("Owner"));

            return new DebtEntry(id, float.Parse(amount), description, dateCreated, frequency, DateTime.Parse(nextPaymentDate), DateTime.Parse(lastPaymentDate), owner);
        }
    }
}
