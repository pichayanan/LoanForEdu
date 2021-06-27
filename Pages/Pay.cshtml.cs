using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class PayModel : PageModel
    {
        public void OnGet()
        {
            amount = 1000;
        }
        [BindProperty]
        public int periods { get; set; } = 1;
        [BindProperty]
        public int amount { get; set; } = 0;
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("");
            return RedirectToPage("./Home");
        }
    }
}
