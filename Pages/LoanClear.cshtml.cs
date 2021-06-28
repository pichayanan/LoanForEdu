using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace MyApp.Namespace
{
    public class LoanClearModel : PageModel
    {
        public void OnGet()
        {
            using (OracleConnection con = new OracleConnection(LoanForEdu.Program.conStringUser))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        Console.WriteLine("New loan clearing request");
                        cmd.CommandText = "UPDATE contract SET Amount=" + 0 + ",RemainingAmount=" + 0 + ",Periods=" + 0 + ",RemainingPeriods=" + 0 + ",payamount=" + 0 + " WHERE ContractID=1";
                        OracleDataReader reader = cmd.ExecuteReader();
                        // while (reader.Read())
                        // {
                        //     Console.WriteLine(reader.GetString(0) + " is done.");
                        // }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error => " + ex.Message);
                    }
                }
            }

        }
    }
}
