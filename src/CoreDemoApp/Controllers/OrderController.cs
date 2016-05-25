using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemoApp.Models;
using CoreDemoApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var  cartItems = GetCartItemsFromSession();
            var model = new OrderModel();
            var orderDetails = new List<OrderDetailsModel>();
            var repository = new AlbumRepository();
            var orderTotal = Convert.ToDecimal(0);
            foreach (var cartItem in cartItems)
            {
                var detail = new OrderDetailsModel();
                var album = repository.GetAlbum(cartItem.AlbumId);
                detail.Album = new AlbumModel
                {
                    Title = album.Title,
                    Price = album.Price
                };
                detail.Quantity = cartItem.Quantity;
                orderDetails.Add(detail);
                orderTotal += album.Price * cartItem.Quantity;
            }
            model.OrderDetails = orderDetails;
            ViewBag.OrderTotal = orderTotal;
            return View(model);
        }

        public JsonResult AddToCart(Guid id, int quantity)
        {
            var cartItem = new CartItemModel { AlbumId = id, Quantity = quantity };
            var cartItems = AddCartItem(cartItem);
            PutCartItemsInSession(cartItems);
            var numberItems = cartItems.Count;
            return Json(new { cartItemNumber = numberItems });
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

            var cartItems = new List<CartItemModel>();
            if (ret)
            {
                cartItems =  BusinessMethods.SerializationLogic<List<CartItemModel>>.Deserialize(bytes);
            }
            return cartItems;

        }
    }
}