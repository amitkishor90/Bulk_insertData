using System;
using System.Data;
using DataAccessLayer;
using BusinessLayer;  

namespace BusinessLayer
{
    public class BulkInsertData : Isavebulkdata
    {
        private readonly IDatabaseService _databaseService;

        // Constructor to inject the dependency
        public BulkInsertData(IDatabaseService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            
        }

        public void InsertBulkOrders(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new ArgumentException("DataTable cannot be null or empty.", nameof(dt));
            }

            try
            {
                // Use the constant from TableNamedb
                
                _databaseService.InsertOrdersToDatabase(Tablenamedb.Orders, dt); // Reference the constant Orders
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while inserting bulk data: {ex.Message}");
                throw;
            }
        }
    }
}
