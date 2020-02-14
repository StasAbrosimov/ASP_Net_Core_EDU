using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;

namespace RazorPages
{
    public class PersonModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Person Person { get; set; }

        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Введите данные";
            if (Person != null && (!string.IsNullOrEmpty(Person.Name) || Person.Age.HasValue))
            {
                Message = $"Имя: {Person.Name}  Возраст: {Person.Age}";
            }
        }
        public void OnPost()
        {
            Message = $"Имя: {Person.Name}  Возраст: {Person.Age}";
        }
    }
}