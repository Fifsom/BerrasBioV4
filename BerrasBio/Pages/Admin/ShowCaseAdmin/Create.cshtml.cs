using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.ShowCaseAdmin
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
        ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
        ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ShowCase ShowCase { get; set; } = default!;
        public Salon Salons { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ShowCase == null || ShowCase == null)
            {
                return Page();
            }

            var size = _context.Salon.Where(x => x.Id == ShowCase.SalonId).FirstOrDefault();
            _context.ShowCase.Add(ShowCase);
            await _context.SaveChangesAsync();
            
            ShowCase.AvailableSeats = size.NumOfSeats;
            _context.ShowCase.Update(ShowCase);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
    }
}
