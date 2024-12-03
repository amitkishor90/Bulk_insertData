using BusinessLayer;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace SQLServerBulkInsert.Controllers
{
    public class BulkDataSaveController : Controller
    {
        private readonly Isavebulkdata _bulkInsertData;

        // Inject Isavebulkdata into the controller
        public BulkDataSaveController(Isavebulkdata bulkInsertData)
        {
            _bulkInsertData = bulkInsertData ?? throw new ArgumentNullException(nameof(bulkInsertData));
        }

        [HttpPost("bulk-insert-orders")]
        public IActionResult BulkInsertOrders(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Convert the uploaded Excel file to a DataTable
                DataTable orders = ConvertExcelToDataTable(file);

                // Call the BulkInsertData method to insert the orders into the database
                _bulkInsertData.InsertBulkOrders(orders);

                return Ok("Bulk orders inserted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Helper method to convert Excel file to DataTable
        private DataTable ConvertExcelToDataTable(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    // Add columns to DataTable based on Excel header row
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                    }

                    // Add rows to DataTable based on Excel data
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var newRow = dataTable.NewRow();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            newRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    return dataTable;
                }
            }
        }
    }
}
