using ApiClients.Order.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Services.Order.Controllers
{
    [Route("Api/Internal/Orders")]
    public sealed class OrdersController : Controller
    {
        public readonly OrderService mOrderService;

        public OrdersController(OrderService orderService)
        {
            mOrderService = orderService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrderAsync([FromBody] XAddOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await mOrderService.AddOrderAsync(request))
            {
                return new ObjectResult(null)
                {
                    StatusCode = 500
                };
            }

            return Ok();
        }

        [HttpGet]
        [Route("ByUserID/{userID}")]
        public async Task<IActionResult> GetOrders([FromRoute] long userID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = await mOrderService.GetOrdersByUserID(userID);

            return Ok(orders);
        }

        [HttpGet]
        [Route("{orderID}")]
        public async Task<IActionResult> GetOrder([FromRoute] long orderID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var order = await mOrderService.GetOrder(orderID);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
