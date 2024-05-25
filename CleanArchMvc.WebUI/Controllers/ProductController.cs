using System.Threading.Tasks;
using CleanArchMvc.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService; 

        public ProductController(IProductService service)
        {
            productService = service;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await  productService.GetProducts();
            return View(products);
        }

    }
}