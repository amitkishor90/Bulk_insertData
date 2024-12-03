using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using Microsoft.Data.SqlClient;

public class DatabaseService : IDatabaseService
{
    private readonly DbConfiguration _dbConfig;

    public DatabaseService(DbConfiguration dbConfig)
    {
        _dbConfig = dbConfig ?? throw new ArgumentNullException(nameof(dbConfig));
    }

    public void InsertOrdersToDatabase(string tablename, DataTable orders)
    {
        if (orders == null || orders.Rows.Count == 0)
        {
            throw new ArgumentException("Orders DataTable cannot be null or empty.", nameof(orders));
        }

        string? connectionString = _dbConfig.ConnectionString;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string cannot be null or empty.");
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = tablename; // Specify the target table name

                try
                {
                    bulkCopy.WriteToServer(orders);
                    Console.WriteLine("Data inserted successfully using SqlBulkCopy!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Consider logging the exception for further analysis
                    throw;
                }
            }
        }
    }
}
