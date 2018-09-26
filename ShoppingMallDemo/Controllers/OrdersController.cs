using Microsoft.AspNetCore.Mvc;

namespace ShoppingMallDemo.Controllers
{
    [Route("Orders")]
    public class OrdersController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetOrder(long ID)
        {
            return Ok();
        }
    }
}