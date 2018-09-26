using Microsoft.AspNetCore.Mvc;

namespace ShoppingMallDemo.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return Ok("Shopping mall ok.");
        }
    }
}