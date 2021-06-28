using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace MyApp.Namespace
{
    public class PayModel : PageModel
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
                        Console.WriteLine("Read loan status");
                        cmd.CommandText = "select remainingperiods from contract " + " WHERE ContractID=1";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            periods = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        if (periods == 0)
                        {
                            amount = 0;
                        }
                        else
                        {
                            cmd.CommandText = "select payamount from contract where contractid=1";
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                amount = reader.GetInt32(0);
                            }
                            reader.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error => " + ex.Message);
                    }
                }
            }

        }
        [BindProperty]
        public int periods { get; set; } = 1;
        [BindProperty]
        public int amount { get; set; } = 0;
        public IActionResult OnPost()
        {
            using (OracleConnection con = new OracleConnection(LoanForEdu.Program.conStringUser))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "select remainingperiods from contract " + " WHERE ContractID=1";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            periods = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        if (periods > 0)
                        {
                            int am = 0;
                            cmd.CommandText = "select remainingamount from contract " + " WHERE ContractID=1";
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                am = reader.GetInt32(0);

                            }
                            am = am - amount;
                            periods = periods - 1;
                            reader.Dispose();
                            // cmd.CommandText = "";
                            cmd.CommandText = "UPDATE contract SET remainingamount=" + am + ",remainingperiods=" + periods + " WHERE ContractID=1";
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0));
                            }
                            reader.Dispose();
                        }
                        if(periods==0){
                            return RedirectToPage("./LoanClear");
                        }else{
                            return RedirectToPage("./PaymentSuccess");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error => " + ex.Message);
                    }
                }
            }
            return RedirectToPage("./PaymentSuccess");
        }
    }
}
