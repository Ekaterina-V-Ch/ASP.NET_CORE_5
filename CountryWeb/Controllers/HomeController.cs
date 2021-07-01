using CountriesWeb.Models;
using CountryWeb.Data;
using CountryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _db = db;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCountry(string name)
        {
            if (name != null)
            {
                try
                {
                    var client = _clientFactory.CreateClient("dataApi");
                    string answer = await client.GetStringAsync(name);
                    string department = "{\"Property1\":" + answer + "}";
                    CountryInfo _values = JsonConvert.DeserializeObject<DataJSON>(department).Property1[0];
                    CountryInfo _data = new CountryInfo
                    {
                        Name = _values.Name,
                        Area = _values.Area,
                        Capital = _values.Capital,
                        Alpha3Code = _values.Alpha3Code,
                        Population = _values.Population,
                        Region = _values.Region
                    };
                    return View(_data);
                }
                catch (Exception ex)
                {
                    string errorString = $"Error getting country: {ex.Message}.\nCheck country name";
                    return RedirectToAction("Error", new { problem = errorString });
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult SaveCountry(CountryInfo obj)
        {
            IEnumerable<Country> _countries = _db.Countries;
            _countries = _countries.Where(s => s.Name.Contains(obj.Name));
            if (_countries.Count() == 0)
            {
                IEnumerable<Region> _region = _db.Regions.Where(s => s.Name.Contains(obj.Region));
                IEnumerable<City> _city = _db.Cities.Where(s => s.Name.Contains(obj.Capital));

                if (_region.Count() == 0)
                {
                    _db.Regions.Add(new Region { Name = obj.Region });
                    _db.SaveChanges();
                    _region = _db.Regions.Where(s => s.Name.Contains(obj.Region));
                }
                if (_city.Count() == 0)
                {
                    _db.Cities.Add(new City { Name = obj.Capital });
                    _db.SaveChanges();
                    _city = _db.Cities.Where(s => s.Name.Contains(obj.Capital));
                }
                Country _countryNew = new Country
                {
                    Name = obj.Name,
                    Code = obj.Alpha3Code,
                    Capital = _city.First().ID,
                    Area = obj.Area,
                    Population = obj.Population,
                    Region = _region.First().ID
                };
                _db.Countries.Add(_countryNew);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult ShowAll()
        {
            IEnumerable<Region> _regions = _db.Regions;
            IEnumerable<City> _cities = _db.Cities;
            IEnumerable<Country> _countries = _db.Countries;
            var query = from Country in _countries
                        join Region in _regions on Country.Region equals Region.ID
                        join City in _cities on Country.Capital equals City.ID
                        select new { Country.Name, Country.Code, Capital = City.Name, Country.Area, Country.Population, Region = Region.Name };
            List<CountryInfo> _countriesList = new List<CountryInfo>();
            foreach (var item in query)
            {
                _countriesList.Add(new CountryInfo
                {
                    Name = (string)item.Name,
                    Area = (float)item.Area,
                    Capital = (string)item.Capital,
                    Alpha3Code = (string)item.Code,
                    Population = (int)item.Population,
                    Region = (string)item.Region
                });
            }
            return View(_countriesList);
        }

        public IActionResult Error(string problem)
        {
            return View(new Error { Name = problem });
        }
    }
}
