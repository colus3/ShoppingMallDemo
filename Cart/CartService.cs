using ApiClients.Cart.Common.DTO;
using Microsoft.EntityFrameworkCore;
using Services.Cart.Data;
using Services.Product.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Cart
{
    public sealed class CartService
    {
        private readonly CartDbContext mDbContext;

        public CartService(CartDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<bool> AddCartItemAsync(long cartID, long productID)
        {
            var cart = await mDbContext.Carts
                .AsNoTracking()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.ID == cartID);

            if (cart == null)
            {
                return false;
            }

            var cartItem = await mDbContext.CartItems.FirstOrDefaultAsync(ci => ci.CartID == cart.ID && ci.ProductID == productID);

            if (cartItem != null)
            {
                cartItem.Quantity += 1;
            }
            else
            {
                mDbContext.CartItems.Add(new Models.Entity.CartItem
                {
                    ProductID = productID,
                    CartID = cart.ID,
                    Quantity = 1
                });
            }

            await mDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<XCart> GetCartAsync(long cartID)
        {
            var cart = await mDbContext.Carts
                .AsNoTracking()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.ID == cartID);

            var xCartItems = new List<XCartItem>();
            if (cart.CartItems != null && cart.CartItems.Any())
            {
                xCartItems = cart.CartItems.Select(c => new XCartItem
                (
                    id: c.ID,
                    productID: c.ProductID.Value,
                    cartID: c.CartID.Value,
                    quantity: c.Quantity.Value
                )).ToList();
            }

            var xCart = new XCart
                (
                    id: cart.ID,
                    totalPrice: cart.TotalPrice.Value,
                    userID: cart.UserID.Value,
                    status: cart.Status.ToEXCartStatus(),
                    cartItems: xCartItems
                );

            return xCart;
        }

        public async Task<XCart> GetCartByUserIDAsync(long userID)
        {
            var cart = await mDbContext.Carts
                .AsNoTracking()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserID.Value == userID && c.Status == Models.Entity.ECartStatus.Active);

            if (cart == null)
            {
                cart = new Models.Entity.Cart
                {
                    ID = userID,
                    TotalPrice = 0,
                    UserID = userID,
                    Status = Models.Entity.ECartStatus.Active,
                };

                mDbContext.Carts.Add(cart);
                await mDbContext.SaveChangesAsync();
            }

            var xCartItems = new List<XCartItem>();
            if (cart.CartItems != null && cart.CartItems.Any())
            {
                xCartItems = cart.CartItems.Select(c => new XCartItem
                (
                    id: c.ID,
                    productID: c.ProductID.Value,
                    cartID: c.CartID.Value,
                    quantity: c.Quantity.Value
                )).ToList();
            }

            var xCart = new XCart
                (
                    id: cart.ID,
                    totalPrice: cart.TotalPrice.Value,
                    userID: cart.UserID.Value,
                    status: cart.Status.ToEXCartStatus(),
                    cartItems: xCartItems
                );

            return xCart;
        }

        public async Task<bool> UpdateCartItemQuantityAsync(long cartItemID, int quantity)
        {
            var cartItem = await mDbContext.CartItems.FirstOrDefaultAsync(ci => ci.ID == cartItemID);

            if (cartItem == null)
            {
                return false;
            }

            cartItem.Quantity = quantity;
            await mDbContext.SaveChangesAsync();

            return true;
        }
    }
}
