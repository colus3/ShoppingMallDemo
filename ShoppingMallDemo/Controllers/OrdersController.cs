using ApiClients.Order.Common;
using ApiClients.Product.Common;
using Microsoft.AspNetCore.Mvc;
using ShoppingMallDemo.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMallDemo.Controllers
{
    [Route("Orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderClient mOrderClient;
        private readonly IProductClient mProductClient;

        public OrdersController(IOrderClient orderClient, IProductClient productClient)
        {
            mOrderClient = orderClient;
            mProductClient = productClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOrders()
        {
            // Usually, you would get userid from an access token, for example. This is hardcoded for simplicity.
            long userID = 1;

            var xOrders = await mOrderClient.GetOrdersByUserID(userID);

            var orders = new List<GetOrderResponse>();

            foreach (var order in xOrders)
            {
                var getproductTasks = order.OrderItems.Select(oi => mProductClient.GetProductAsync(oi.ProductID)).ToList();

                var orderItems = new List<GetOrderResponseItem>();
                for (int i = 0; i < getproductTasks.Count; i++)
                {
                    var product = await getproductTasks[i];

                    orderItems.Add(new GetOrderResponseItem(
                        id: order.OrderItems[i].ID,
                        productID: product.ID,
                        productName: product.Name,
                        price: product.Price,
                        quantity: order.OrderItems[i].Quantity
                    ));
                }

                orders.Add(new GetOrderResponse(
                        id: order.ID,
                        totalPrice: orderItems.Sum(ci => ci.Price * ci.Quantity),
                        address: order.Address,
                        deliveryMethod: order.DeliveryMethod,
                        orderStatus: order.OrderStatus,
                        orderItems: orderItems
                    ));
            }

            return Ok(orders);
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<IActionResult> GetOrder([FromRoute] long ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var order = await mOrderClient.GetOrder(ID);

            var getproductTasks = order.OrderItems.Select(oi => mProductClient.GetProductAsync(oi.ProductID)).ToList();

            var orderItems = new List<GetOrderResponseItem>();
            for (int i = 0; i < getproductTasks.Count; i++)
            {
                var product = await getproductTasks[i];

                orderItems.Add(new GetOrderResponseItem(
                    id: order.OrderItems[i].ID,
                    productID: product.ID,
                    productName: product.Name,
                    price: product.Price,
                    quantity: order.OrderItems[i].Quantity
                ));
            }

            return Ok(new GetOrderResponse(
                    id: order.ID,
                    totalPrice: orderItems.Sum(ci => ci.Price * ci.Quantity),
                    address: order.Address,
                    deliveryMethod: order.DeliveryMethod,
                    orderStatus: order.OrderStatus,
                    orderItems: orderItems
                ));
        }
    }
}