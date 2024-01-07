using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Watchmasters.Data;
using Watchmasters.Models;

namespace Watchmasters.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly Watchmasters.Data.WatchmastersContext _context;

        public CreateModel(Watchmasters.Data.WatchmastersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PrefStoreID"] = new SelectList(_context.Set<Store>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
