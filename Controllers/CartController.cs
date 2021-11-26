using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953505_Grits.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using WEB_953505_Grits.Data;
using WEB_953505_Grits.Extensions;


namespace WEB_953505_Grits.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private string cartKey = "cart";
        private Cart _cart;
        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Index()
        {
            //var _cart = HttpContext.Session.Get<Cart>(cartKey);
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            //var _cart = HttpContext.Session.Get<Cart>(cartKey);
            var item = _context.Bouquets.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
               // HttpContext.Session.Set<Cart>(cartKey, _cart);
            }
            return Redirect(returnUrl);
        }
        public IActionResult Delete(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
