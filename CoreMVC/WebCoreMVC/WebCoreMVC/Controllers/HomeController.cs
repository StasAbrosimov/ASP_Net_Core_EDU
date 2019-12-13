using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCoreMVC.Models;
using WebCoreMVC.Models.DBContext;

namespace WebCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        ILogger logger;
        public HomeController(MobileContext context, ILogger<HomeController> logg)
        {
            db = context;
            logger = logg;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            var someForm = Request.Form.ToList();
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }

        public string Hello(int? id, int? some, string someStr)
        {
            var someV = some.HasValue ? some.Value.ToString() : "some";
            return $"Hello :{id} some int:{someV} someStr:{someStr}";
        }

        public string Object(string id, Somting someO)
        {
            return $"Some Obj: {someO?.GetResult()}\n Id:{id}";
        }

        public string Objects(string id, Somting[] objs)
        {
            var someReq = Request.Query.ToList();
            var builder = new System.Text.StringBuilder();
            builder.AppendLine("Objects:");
            builder.AppendLine($"id: {id}");
            if(objs != null && objs.Length > 0)
            {
                foreach (var item in objs)
                {
                    builder.AppendLine($"Some Obj: {item?.GetResult()}");
                }
            }
            else
            {
                builder.AppendLine("objs is empty");
            }

            return builder.ToString();
        }

        public Somting GetSome(string id, int? some, string someStr)
        {
            return new Somting() { SomeId = some, someString = someStr };
        }

        public IActionResult DoSome(string id)
        {
            logger.LogDebug($"Id is: {id}");

            return new JsonResult(new Somting() { SomeId = 123, someString = id });
        }
    }


    public class Somting
    {
        public int? SomeId { get; set; }
        public string someString { get; set; }

        public string GetResult()
        {
            return $"Somting someInt:{SomeId} someStr:{someString}";
        }
    }
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}
