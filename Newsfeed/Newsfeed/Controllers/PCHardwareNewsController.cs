using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Data;
using Newsfeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Controllers
{
    public class PCHardwareNewsController : Controller
    {
        private readonly NewsfeedDbContext _db;

        public PCHardwareNewsController(NewsfeedDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<PCHardwareNews> objList = _db.PCNews;
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
        public IActionResult Create(PCHardwareNews obj)
        {
            obj.DateTimeCreated = DateTime.Now;
            obj.DateTimeUpdated = DateTime.Now;
            _db.PCNews.Add(obj);
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
            var obj = _db.PCNews.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PCHardwareNews obj)
        {
            obj.DateTimeUpdated = DateTime.Now;
            _db.PCNews.Update(obj);
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
            var obj = _db.PCNews.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PCNews.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
