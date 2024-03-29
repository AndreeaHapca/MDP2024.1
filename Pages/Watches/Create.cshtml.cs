﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Watchmasters.Data;
using Watchmasters.Models;

namespace Watchmasters.Pages.Watches
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
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Watch Watch { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Watch.Add(Watch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
