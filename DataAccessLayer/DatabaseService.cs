using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using Microsoft.Data.SqlClient;

public class DatabaseService : IDatabaseService
{
    public void InsertOrdersToDatabase(string connectionString, DataTable orders)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }

        if (orders == null || orders.Rows.Count == 0)
        {
            throw new ArgumentException("Orders DataTable cannot be null or empty.", nameof(orders));
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = "Orders"; // Specify the target table name

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
