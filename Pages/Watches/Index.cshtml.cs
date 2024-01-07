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
    public class IndexModel : PageModel
    {
        private readonly Watchmasters.Data.WatchmastersContext _context;

        public IndexModel(Watchmasters.Data.WatchmastersContext context)
        {
            _context = context;
        }

        public IList<Watch> Watch { get;set; }

        public async Task OnGetAsync()
        {
            Watch = await _context.Watch.Include(w => w.Store).ToListAsync();
        }
    }
}
