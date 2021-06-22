using Microsoft.AspNetCore.Mvc;
using Newsfeed.Data;
using Newsfeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Controllers
{
    public class SmartphonesNewsController : Controller
    {
        private readonly NewsfeedDbContext _db;

        public SmartphonesNewsController(NewsfeedDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SmartphonesNews> objList = _db.PhonesNews;
            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SmartphonesNews obj)
        {
            obj.DateTimeCreated = DateTime.Now;
            obj.DateTimeUpdated = DateTime.Now;
            _db.PhonesNews.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.PhonesNews.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SmartphonesNews obj)
        {
            obj.DateTimeUpdated = DateTime.Now;
            _db.PhonesNews.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Post-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.PhonesNews.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PhonesNews.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
