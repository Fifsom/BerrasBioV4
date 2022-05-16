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
    public class IndexModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public IndexModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

        public IList<ShowCase> ShowCase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ShowCase != null)
            {
                ShowCase = await _context.ShowCase
                .Include(s => s.Movie)
                .Include(s => s.Salon).ToListAsync();
            }
        }
    }
}
