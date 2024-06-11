using Microsoft.AspNetCore.Mvc;

namespace PerfumeStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
