using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953505_Grits.Data;
using WEB_953505_Grits.Entities;

namespace WEB_953505_Grits.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_953505_Grits.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953505_Grits.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bouquet> Bouquet { get;set; }

        public async Task OnGetAsync()
        {
            Bouquet = await _context.Bouquets
                .Include(b => b.Group).ToListAsync();
        }
    }
}
