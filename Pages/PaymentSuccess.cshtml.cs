using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace MyApp.Namespace
{
    public class PaymentSuccessModel : PageModel
    {
        [BindProperty]
        public int amount { get; set; } = 0;
        public void OnGet()
        {
            using (OracleConnection con = new OracleConnection(LoanForEdu.Program.conStringUser))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        Console.WriteLine("Read loan status");
                        cmd.CommandText = "select payamount from contract where contractid=1";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            amount = reader.GetInt32(0);
                        }
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
