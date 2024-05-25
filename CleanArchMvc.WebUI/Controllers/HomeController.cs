using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Privacy()
        {
            return View();
        }

    }
}