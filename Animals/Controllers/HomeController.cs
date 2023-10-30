using Animals.Models;
using Animals.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Animals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatApiServices catApiServices;

       public HomeController(ICatApiServices catApiServices)
        {
            this.catApiServices = catApiServices;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Cat> result = new List<Cat>();
            try
            {
                result = await catApiServices.AllInfoCatsAsync();

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(result);

        }
        public async Task<IActionResult> SearchCat(string name)
        {
            Cat cat = new Cat();
            try
            {
                var result = await catApiServices.AllInfoCatsAsync();
                cat = result.FirstOrDefault(c => c.name == name);

                var photo = await catApiServices.SearchCat(cat);
                cat.photos = photo;
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.Message;
            }
            return View(cat);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}