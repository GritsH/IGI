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
    public class DeleteModel : PageModel
    {
        private readonly WEB_953505_Grits.Data.ApplicationDbContext _context;

        public DeleteModel(WEB_953505_Grits.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bouquet Bouquet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bouquet = await _context.Bouquets
                .Include(b => b.Group).FirstOrDefaultAsync(m => m.BouquetId == id);

            if (Bouquet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bouquet = await _context.Bouquets.FindAsync(id);

            if (Bouquet != null)
            {
                _context.Bouquets.Remove(Bouquet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
