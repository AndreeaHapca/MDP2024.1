using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Watchmasters.Data;
using Watchmasters.Models;

namespace Watchmasters.Pages.Watches
{
    public class DeleteModel : PageModel
    {
        private readonly Watchmasters.Data.WatchmastersContext _context;

        public DeleteModel(Watchmasters.Data.WatchmastersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Watch Watch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Watch = await _context.Watch.FirstOrDefaultAsync(m => m.ID == id);

            if (Watch == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Watch = await _context.Watch.FindAsync(id);

            if (Watch != null)
            {
                _context.Watch.Remove(Watch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
