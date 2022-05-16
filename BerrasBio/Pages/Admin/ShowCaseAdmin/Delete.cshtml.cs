using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.ShowCaseAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public DeleteModel(BerrasBio.Data.BerrasBioContext context)
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

            var showcase = await _context.ShowCase.FirstOrDefaultAsync(m => m.Id == id);

            if (showcase == null)
            {
                return NotFound();
            }
            else 
            {
                ShowCase = showcase;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ShowCase == null)
            {
                return NotFound();
            }
            var showcase = await _context.ShowCase.FindAsync(id);

            if (showcase != null)
            {
                ShowCase = showcase;
                _context.ShowCase.Remove(ShowCase);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
