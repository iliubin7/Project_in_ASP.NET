using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public IndexModel(WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Alcohol> Alcohol { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Alcohol = await _context.Alcohol.ToListAsync();
            return Page();
        }
    }
}
