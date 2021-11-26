using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953505_Grits.Data;
using WEB_953505_Grits.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WEB_953505_Grits.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_953505_Grits.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_953505_Grits.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["BouquetGroupId"] = new SelectList(_context.BouquetGroups, "BouquetGroupId", "BouquetGroupId");
            return Page();
        }

        [BindProperty]
        public Bouquet Bouquet { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bouquets.Add(Bouquet);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Bouquet.BouquetId}" + Path.GetExtension(Image.FileName);
                Bouquet.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
