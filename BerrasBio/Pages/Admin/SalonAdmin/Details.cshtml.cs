using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.SalonAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public DetailsModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

      public Salon Salon { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Salon == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon.FirstOrDefaultAsync(m => m.Id == id);
            if (salon == null)
            {
                return NotFound();
            }
            else 
            {
                Salon = salon;
            }
            return Page();
        }
    }
}
