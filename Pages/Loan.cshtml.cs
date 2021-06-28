using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace LoanForEdu
{
    public class LoanModel : PageModel
    {
        [BindProperty]
        public int salary { get; set; } = 0;
        [BindProperty]
        public int net_salary { get; set; } = 0;

        [BindProperty]
        public int periods { get; set; } = 1;
        [BindProperty]
        public int amount { get; set; } = 0;
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            using (OracleConnection con = new OracleConnection(LoanForEdu.Program.conStringUser))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        Console.WriteLine("New loan request");
                        if (amount <= (net_salary * periods) && net_salary <= salary)
                        {
                            int ppay = amount / periods;
                            Console.WriteLine("Loan request was approved.");
//                             cmd.CommandText = "delete from contract where contractid=1;"
// + "ALTER TABLE contract ADD amount integer;"
// + "ALTER TABLE contract ADD contractid integer;"
// + "ALTER TABLE contract ADD REMAININGAMOUNT integer;"
// + "ALTER TABLE contract ADD PERIODS integer;"
// + "ALTER TABLE contract ADD REMAININGPERIODS integer;"
// + "ALTER TABLE contract ADD payamount integer;"
// + "INSERT INTO contract (ContractID,Amount,RemainingAmount,Periods,RemainingPeriods, payamount) VALUES (1,0,0,0,0,0);";
                            cmd.CommandText = "UPDATE contract SET Amount=" + amount + ",RemainingAmount=" + amount + ",Periods=" + periods + ",RemainingPeriods=" + periods + ",payamount=" + ppay + " WHERE ContractID=1";
                            OracleDataReader reader = cmd.ExecuteReader();
                            // while (reader.Read())
                            // {
                            //     Console.WriteLine(reader.GetString(0) + " is done.");
                            // }
                            reader.Dispose();
                            return RedirectToPage("./Approved");
                        }
                        else
                        {
                            Console.WriteLine("Loan request was not approved.");
                            return RedirectToPage("./Fail");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error => " + ex.Message);
                    }
                    return RedirectToPage("./Fail");
                }
            }
        }
    }
}
