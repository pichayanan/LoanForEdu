using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("Salary " + salary + " NetSalary " + net_salary + " Pr " + periods);
            return RedirectToPage("./Home");
        }
    }
    public class ClickController : Controller
    {
        LoanModel model;
        public void Submit(){
            Console.WriteLine(model.salary);
        }

    }
}
