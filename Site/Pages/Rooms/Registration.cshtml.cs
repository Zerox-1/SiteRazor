using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.Data;
using Site.Models;
using System.ComponentModel.DataAnnotations;

namespace Site.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly SiteContext _context;

        public RegistrationModel(SiteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_context.User.Any(u => u.Phone == Input.Phone))
            {
                ModelState.AddModelError("Input.Phone", "Ќомер уже зарегистрирован.");
                return Page();
            }
            if (_context.User.Any(u => u.Email == Input.Email))
            {
                ModelState.AddModelError("Input.Email", "Email уже зарегистрирован.");
                return Page();
            }
            User nw = new User
            {
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Password = Input.Password,
                Email = Input.Email,
                Phone = Input.Phone,
                Role = Input.Role == "tenant" ? 1 : 2
            };

            _context.User.Add(nw);
            _context.SaveChanges();
            return RedirectToPage("Index"); 
        }
    }
}
