using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953505_Grits.Entities;
using WEB_953505_Grits.Models;

namespace WEB_953505_Grits.Controllers
{
    public class ProductController: Controller
    {
        private List<Bouquet> _bouquets;
        private List<BouquetGroup> _bouquetGroups;

        int _pageSize;

        public ProductController()
        {
            SetupData();
            _pageSize = 3;
        }

        public IActionResult Index(int? group, int pageNo=1)
        {
            var bouquetFiltered = _bouquets.Where(b => !group.HasValue || b.BouquetGroupId == group.Value);
            ViewData["Groups"] = _bouquetGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Bouquet>.GetModel(bouquetFiltered, pageNo,_pageSize));
        }

        private void SetupData()
        {
            _bouquetGroups = new List<BouquetGroup>
            {
                new BouquetGroup{BouquetGroupId=1, GroupName = "Wedding"},
                new BouquetGroup{BouquetGroupId=2, GroupName = "Birthdays"},
                new BouquetGroup{BouquetGroupId=3, GroupName = "For family and friends"},
                new BouquetGroup{BouquetGroupId =4, GroupName = "Valentain's day"}
            };

            _bouquets = new List<Bouquet>
            {
                new Bouquet {BouquetId = 1, BouquetName = "Janet", 
                    Description = "Вelicate aroma and calm composition", Image="buket1.jpg",
                BouquetGroupId = 1},

                new Bouquet {BouquetId = 2, BouquetName = "Lilian",
                Description = "Colorful bouquet with lilies", Image = "buket6.jpg",
                BouquetGroupId = 2},

                new Bouquet {BouquetId = 3, BouquetName = "Vivien", 
                Description="Simple bouquet in pastel colors", Image="buket3.jpg", BouquetGroupId = 3},

                new Bouquet{BouquetId = 4, BouquetName="Aurelia", 
                Description = "Perfect bouquet to express your love", Image = "buket5.jpg", BouquetGroupId=4 },

                new Bouquet{BouquetId = 5, BouquetName="Prez",
                Description="Modest but significant", Image="buket4.jpg", BouquetGroupId = 4},

                new Bouquet{BouquetId = 6, BouquetName="Maria", 
                Description = "Delicate peonies and sweetish aroma", Image="buket2.jpg", BouquetGroupId=3},

                new Bouquet{BouquetId = 7, BouquetName="Donna", 
                Description="Little bouquet for big event", Image="buket7.jpg", BouquetGroupId=1},

                new Bouquet{BouquetId=8, BouquetName="Jacklin", 
                Description="Strict and simple", Image="buket8.jpg", BouquetGroupId = 2},

                new Bouquet{BouquetId=9, BouquetName = "Violet", 
                Description="Pastel colors and charming composition", Image="buket9.jpg", BouquetGroupId=1},

                new Bouquet{BouquetId=10, BouquetName="Miranda",
                Description="Suitable for birthdays", Image = "buket11.jpg", BouquetGroupId=2},

                new Bouquet{BouquetId=11, BouquetName="Samantha", 
                Description = "Soozing aroma and colors", Image="buket12.jpg", BouquetGroupId=3},

                new Bouquet{BouquetId=12, BouquetName="Singyang",
                Description = "Fiery bouquet for your significant other", Image="buket13.jpg", BouquetGroupId = 4}
            };
        }
    }
}
