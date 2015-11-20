
namespace Utils
{
    public class ConnectionString
    {
        //ConfigurationManager.AppSettings["ConnectionString"];
        public static string SqlServerConnectionString = "server=.;database=test;uid=sa;pwd=123";

        public static string AccessConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=|DataDirectory|test.mdb"; //Access数据库必须放在App_Data

        public static string MySqlConnettionString = "server=localhost;database=test;uid=root;Charset=utf8";

        public static string OracleConnectionString = "Provider=OraOLEDB.Oracle.1;Data Source=orcl;User ID=sysman;Password=sa;Unicode=True";
    }
}
