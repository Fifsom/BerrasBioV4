using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.ShowCaseAdmin
{
    public class EditModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public EditModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShowCase ShowCase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShowCase == null)
            {
                return NotFound();
            }

            var showcase =  await _context.ShowCase.FirstOrDefaultAsync(m => m.Id == id);
            if (showcase == null)
            {
                return NotFound();
            }
            ShowCase = showcase;
           ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
           ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
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

            _context.Attach(ShowCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowCaseExists(ShowCase.Id))
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

        private bool ShowCaseExists(int id)
        {
          return (_context.ShowCase?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
