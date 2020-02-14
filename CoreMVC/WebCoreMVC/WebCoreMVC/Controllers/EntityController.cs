using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreMVC.Models;
using WebCoreMVC.Models.DBContext;
using WebCoreMVC.Models.DBModels;

namespace WebCoreMVC.Controllers
{
    public class EntityController : Controller
    {
        private MobileContext db;
        public EntityController(MobileContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int? DeleteId)
        {
            if (ModelState.IsValid && DeleteId != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == DeleteId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Sort(SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            //int pageSize = 2;
            //IQueryable<User> users = db.Users.Include(x => x.Company);

            //users = sortOrder switch
            //{
            //    SortState.NameDesc => users.OrderByDescending(s => s.Name),
            //    SortState.AgeAsc => users.OrderBy(s => s.Age),
            //    SortState.AgeDesc => users.OrderByDescending(s => s.Age),
            //    SortState.CompanyAsc => users.OrderBy(s => s.Company.Name),
            //    SortState.CompanyDesc => users.OrderByDescending(s => s.Company.Name),
            //    _ => users.OrderBy(s => s.Name),
            //};

            //var count = await users.CountAsync();
            //var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //PageViewModel pageVM = new PageViewModel(count, page, pageSize);

            SortViewModel viewModel = new SortViewModel();
            //{
            //    Users = items,
            //    SortUsersModel = new SortUsersModel(sortOrder),
            //    PageViewModel = pageVM
            //};
            return View(viewModel);
        }
    }
}