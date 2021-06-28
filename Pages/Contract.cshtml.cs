using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace MyApp.Namespace
{
    public class ContractModel : PageModel
    {
        [BindProperty]
        public int amount { get; set; } = 0;
        [BindProperty]
        public int remain_amount { get; set; } = 0;
        [BindProperty]
        public int periods { get; set; } = 0;
        [BindProperty]
        public int remain_periods { get; set; } = 0;
        [BindProperty]
        public int payamount { get; set; } = 0;
        public void OnGet()
        {
            using (OracleConnection con = new OracleConnection(LoanForEdu.Program.conStringUser))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        Console.WriteLine("Successfully connected to Oracle Database as Contrac ");
                        Console.WriteLine();

                        //Retrieve sample data
                        cmd.CommandText = "select amount from contract where contractID=1";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            amount = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        cmd.CommandText = "select remainingamount from contract where contractID=1";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            remain_amount = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        cmd.CommandText = "select periods from contract where contractID=1";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            periods = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        cmd.CommandText = "select remainingperiods from contract where contractID=1";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            remain_periods = reader.GetInt32(0);
                        }
                        reader.Dispose();
                        cmd.CommandText = "select payamount from contract where contractID=1";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            payamount = reader.GetInt32(0);
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
