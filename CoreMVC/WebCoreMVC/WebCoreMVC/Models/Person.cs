using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreMVC.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Form", ErrorMessage = "Email уже используется")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Some message")]
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
