using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
    public class ProductController: Controller
    {
        public IActionResult ProductDetail(){
            return View();

        }
        public IActionResult ListProduct(){
            return View();
        }
    }
}