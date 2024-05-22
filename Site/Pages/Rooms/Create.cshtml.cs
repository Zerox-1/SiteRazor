using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Site.Data;
using Site.Models;

namespace Site.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;
        public bool fl;
        public CurrentUser nw;
        public CreateModel(Site.Data.SiteContext context)
        {
            _context = context;

        }

        public IActionResult OnGet()
        {
            fl = _context.CurrentUser.Any();
            if (fl)
            {
                nw = _context.CurrentUser.First();
            }
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Room == null || Room == null)
            {
                return Page();
            }
            Room.LordId = _context.CurrentUser.First().Id;
            _context.Room.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
