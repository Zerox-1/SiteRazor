using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;
        public bool fl;
        public CurrentUser nw;
        public IndexModel(Site.Data.SiteContext context)
        {
            _context = context;
            fl = _context.CurrentUser.Any();
            if (fl)
            {
                nw = _context.CurrentUser.First();
            }
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Room != null)
            {
                Room = await _context.Room.ToListAsync();
            }
        }
    }
}
