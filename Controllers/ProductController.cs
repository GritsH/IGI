using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953505_Grits.Entities;
using WEB_953505_Grits.Models;
using WEB_953505_Grits.Extensions;
using WEB_953505_Grits.Data;

namespace WEB_953505_Grits.Controllers
{
    public class ProductController: Controller
    {

        int _pageSize;
        ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _pageSize = 3;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo=1)
        {
            var bouquetFiltered = _context.Bouquets.Where(b => !group.HasValue || b.BouquetGroupId == group.Value);
            ViewData["Groups"] = _context.BouquetGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Bouquet>.GetModel(bouquetFiltered, pageNo,_pageSize);

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(ListViewModel<Bouquet>.GetModel(bouquetFiltered, pageNo,_pageSize));
        }

    }
}
