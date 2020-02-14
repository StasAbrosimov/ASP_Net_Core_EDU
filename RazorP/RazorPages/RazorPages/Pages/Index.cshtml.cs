using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? Age { get; set; }
        public bool IsCorrect { get; set; } = true;
        public void OnGet(string name, int? age)
        {
             if (age == null || age < 1 || age > 110 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
            Age = age;
            Name = name;
        }
    }
}
