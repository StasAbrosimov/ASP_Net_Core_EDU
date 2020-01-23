using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebCoreMVC.Models;
using WebCoreMVC.Exstensions;

namespace WebCoreMVC.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person != null)
                {
                    return Content(content: $"{person.Name} - {person.Email}");
                }
                else
                {
                    return StatusCode(HttpStatusCode.BadRequest.StatusToInt());
                }
            }
            else
                return View(person);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            if (email == "admin@gmail.com" || email == "aaa@gmail.com" || email == "111@gmail.com")
                return Json(false);
            return Json(true);
        }
    }
}