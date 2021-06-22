using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newsfeed.Data;
using Newsfeed.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Newsfeed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly NewsfeedDbContext _db;

        public HomeController(ILogger<HomeController> logger, NewsfeedDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<PCHardwareNews> PCList = _db.PCNews;
            IEnumerable<SmartphonesNews> PhonesList = _db.PhonesNews;
            IList<Home> objList = new List<Home>();
            foreach(var news in PCList)
            {
                objList.Add(news);
            }
            foreach (var news in PhonesList)
            {
                objList.Add(news);
            }
            IEnumerable<Home> objListSorted = objList.OrderByDescending(n => n.DateTimeCreated);
            return View(objListSorted);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
