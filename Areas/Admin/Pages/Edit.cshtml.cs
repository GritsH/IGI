using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_953505_Grits.Data;
using WEB_953505_Grits.Entities;

namespace WEB_953505_Grits.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WEB_953505_Grits.Data.ApplicationDbContext _context;

        public EditModel(WEB_953505_Grits.Data.ApplicationDbContext context)
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
           ViewData["BouquetGroupId"] = new SelectList(_context.BouquetGroups, "BouquetGroupId", "BouquetGroupId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bouquet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BouquetExists(Bouquet.BouquetId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BouquetExists(int id)
        {
            return _context.Bouquets.Any(e => e.BouquetId == id);
        }
    }
}
