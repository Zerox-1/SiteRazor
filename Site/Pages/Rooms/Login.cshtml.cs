using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.Data;
using Site.Models;

namespace Site.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SiteContext _context;

        public LoginModel(SiteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LoginInputModel Input { get; set; }
        public bool fl;
        public CurrentUser nw;
        public void OnGet()
        {
            fl = _context.CurrentUser.Any();
            if (fl)
            {
                nw = _context.CurrentUser.First();
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!_context.User.Any(u => u.Email == Input.Email))
            {
                ModelState.AddModelError("Input.Email", "Email не зарегистрирован.");
                return Page();
            }
            if (_context.User.First(u => u.Email == Input.Email).Password != Input.Password)
            {
                ModelState.AddModelError("Input.Password", "Ќе верный пароль.");
                return Page();
            }
            var e = _context.User.First(u => u.Email == Input.Email);
            nw = new CurrentUser {
                Id = e.Id,
                FirstName=e.FirstName,
                LastName=e.LastName,
                Phone=e.Phone,
                Email=e.Email,
                Password=e.Password,
                Role=e.Role
            };

            _context.CurrentUser.Add(nw);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
        public IActionResult OnPostExit()
        {
            _context.CurrentUser.Remove(_context.CurrentUser.First());
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
