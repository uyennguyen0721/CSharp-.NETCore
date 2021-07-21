using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_Razor_EntityFramework.Data;
using ASP_Razor_EntityFramework.Models;

namespace ASP_Razor_EntityFramework.Pages_Blog
{
    public class CreateModel : PageModel
    {
        private readonly ASP_Razor_EntityFramework.Data.ArticleContext _context;

        public CreateModel(ASP_Razor_EntityFramework.Data.ArticleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
