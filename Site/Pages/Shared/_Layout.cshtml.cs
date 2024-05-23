using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Site.Pages.Shared
{
    public class _Layout : PageModel
    {

        private readonly Site.Data.SiteContext _context;
        public _Layout(Site.Data.SiteContext context)
        {
            _context = context;
        }
        public bool fl;
        public void OnGet()
        {
            fl = !_context.CurrentUser.Any();
        }
    }
}
