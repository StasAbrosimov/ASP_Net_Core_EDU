using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClaimsApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClaimsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "OnlyForLondon")]
        public IActionResult AdminPage()
        {
            return View();
        }

        [Authorize(Policy = "OnlyForMicrosoft")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Policy = "AgeLimit")]
        public IActionResult AgePage()
        {
            return Content("too old");
        }

        public IActionResult TooYoung()
        {
            return Content("Too Young");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
