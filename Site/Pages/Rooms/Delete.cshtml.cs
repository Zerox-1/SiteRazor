﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public DeleteModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }
            var room = await _context.Room.FindAsync(id);

            if (room != null)
            {
                Room = room;
                _context.Room.Remove(Room);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
