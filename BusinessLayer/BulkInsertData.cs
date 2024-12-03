using System.Data;
using DataAccessLayer;

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
                _databaseService.InsertOrdersToDatabase(dt); // Call the DatabaseService method
                Console.WriteLine("Bulk insert completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while inserting bulk data: {ex.Message}");
                throw;
            }
        }
    }
}
