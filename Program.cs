using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace LoanForEdu
{
    public class Program
    {
        public static string user = "system";
        public static string pwd = "Palm21465235";
        public static string db = "localhost:1521/XE";
        public static string conStringUser = "";
        public static void Main(string[] args)
        {
            conStringUser = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
