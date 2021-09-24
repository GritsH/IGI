using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953505_Grits.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB_953505_Grits.Components
{
    public class MenuViewComponent: ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 2"},
            new MenuItem{ Controller="Product", Action="Index", Text="Catalog"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Administration" }
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            foreach(var item in _menuItems)
            {
                var _matchController = controller?.Equals(item.Controller) ?? false;
                var _matchArea = area?.Equals(item.Area) ?? false;
                if(_matchController||_matchArea)
                {
                    item.Action = "active";
                }
            }

            return View(_menuItems);
        }
    }
}
