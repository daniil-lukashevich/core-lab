using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class HelpersModel : PageModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var a = "test";
        }
    }
}
