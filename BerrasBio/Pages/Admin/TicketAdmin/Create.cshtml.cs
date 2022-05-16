using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBio.Data;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Pages.Admin.TicketAdmin
{
    public class CreateModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public CreateModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

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
            Show = showcase;
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;
        [BindProperty]
        public ShowCase Show { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Ticket == null || Ticket == null)
            {
                return Page();
            }

            var calculation = _context.ShowCase.Where(m => m.Id == Show.Id).FirstOrDefault();
            if(Ticket.NumOfTickets <= calculation.AvailableSeats)
            {
                calculation.AvailableSeats -= Ticket.NumOfTickets;
            }
            else
            {
                return Page();
            }
            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            _context.ShowCase.Update(calculation);
            await _context.SaveChangesAsync();

            return RedirectToPage($"./Details", new { id= Ticket.Id});
        }
    }
}
