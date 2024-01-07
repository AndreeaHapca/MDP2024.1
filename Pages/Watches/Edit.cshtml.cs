using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watchmasters.Data;
using Watchmasters.Models;

namespace Watchmasters.Pages.Watches
{
    public class EditModel : PageModel
    {
        private readonly Watchmasters.Data.WatchmastersContext _context;

        public EditModel(Watchmasters.Data.WatchmastersContext context)
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
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Watch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(Watch.ID))
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

        private bool WatchExists(int id)
        {
            return _context.Watch.Any(e => e.ID == id);
        }
    }
}
