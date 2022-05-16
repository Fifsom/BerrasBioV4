using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.SalonAdmin
{
    public class CreateModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public CreateModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Salon Salon { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Salon == null || Salon == null)
            {
                return Page();
            }

            _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
