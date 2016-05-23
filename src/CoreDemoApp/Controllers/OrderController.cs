using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var  cartItems = GetCartItemsFromSession();
            return View(cartItems);
        }

        public JsonResult AddToCart(Guid id, int quantity)
        {
            var cartItem = new CartItemModel { AlbumId = id, Quantity = quantity };
            var cartItems = AddCartItem(cartItem);
            PutCartItemsInSession(cartItems);
            return Json(new { result = "ok" });
        }

        private List<CartItemModel> AddCartItem(CartItemModel cartItem)
        {
            List<CartItemModel> cartItems = null;
            cartItems = GetCartItemsFromSession();
            cartItems.Add(cartItem);
            return cartItems;
        }

        private void PutCartItemsInSession(List<CartItemModel> cartItems)
        {
            var bytes = BusinessMethods.SerializationLogic<List<CartItemModel>>.Serialize(cartItems);
            HttpContext.Session.Set("cartItems", bytes);
        }

        private List<CartItemModel> GetCartItemsFromSession()
        {
            byte[] bytes;
            var ret = HttpContext.Session.TryGetValue("cartItems", out bytes);
            if (ret)
            {
                return BusinessMethods.SerializationLogic<List<CartItemModel>>.Deserialize(bytes);
            }
            return new List<CartItemModel>();

        }
    }
}