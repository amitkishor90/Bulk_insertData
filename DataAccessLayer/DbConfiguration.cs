using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class DbConfiguration
    {
        public string? ConnectionString { get; set; }
        public DbConfiguration(IConfiguration configuration)
        {
            // You can read the connection string from appsettings.json or environment variables
            ConnectionString = configuration.GetConnectionString("MyDatabaseConnection");
        }
    }
}
