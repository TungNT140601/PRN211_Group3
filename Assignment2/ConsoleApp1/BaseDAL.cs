using System.IO;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Demo
{
    public class BaseDAL
    {
        public static StockDataProvider dataProvider { get; set; } = null;
        public static SqlConnection connection = null;
        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }
        //----------------------------------------------------------
        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionString:FStore"];
            return connectionString;
        }
        //----------------------------------------------------------
        public static void CloseConnection() => dataProvider.CloseConnection(connection);
    }
}
