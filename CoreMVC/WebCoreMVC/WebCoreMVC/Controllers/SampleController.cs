using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCoreMVC.Controllers
{
    public class SampleController : Controller
    {

        private readonly IWebHostEnvironment _webHost;

        public SampleController(IWebHostEnvironment hostEnvironment)
        {
            this._webHost = hostEnvironment;
        }

        public IActionResult GetPrice()
        {
            string filePath = Path.Combine(_webHost.ContentRootPath, "Files/price.pdf");
            string fileType = "application/pdf";
            string fileName = "price.pdf";

            return PhysicalFile(filePath, fileType, fileName);
        }

        public IActionResult GetMap(string id)
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            return Content($"controller: {controller} | action: {action}");
        }

        #region sample
        // GET: Sample
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Sample/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Sample/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Sample/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Sample/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Sample/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Sample/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Sample/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
    }
}