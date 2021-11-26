using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB_953505_Grits.Models;
using WEB_953505_Grits.Extensions;


namespace WEB_953505_Grits.Components
{
    public class CartViewComponent: ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            //var cart = HttpContext.Session.Get<Cart>("cart");
            return View(_cart);
        }
    }
}
