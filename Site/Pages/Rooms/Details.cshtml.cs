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
    public class DetailsModel : PageModel
    {
        public readonly Site.Data.SiteContext _context;

        public bool fl;
        public CurrentUser nw;
        public DetailsModel(Site.Data.SiteContext context)
        {
            _context = context;
            fl = _context.CurrentUser.Any();
            if (fl)
            {
                nw = _context.CurrentUser.First();
            }
        }

      public Room Room { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
        public IActionResult OnPostRent(int? id)
        {
            var room = _context.Room.FirstOrDefault(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                Room = room;
            }
            Room.Rented = 1;
            _context.Room.Update(Room);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
