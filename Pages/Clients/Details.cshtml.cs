using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Watchmasters.Data;
using Watchmasters.Models;

namespace Watchmasters.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly Watchmasters.Data.WatchmastersContext _context;

        public DetailsModel(Watchmasters.Data.WatchmastersContext context)
        {
            _context = context;
        }

        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client
                .Include(c => c.PrefStore).FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
