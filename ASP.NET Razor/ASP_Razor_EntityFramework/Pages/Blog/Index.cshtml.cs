﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_Razor_EntityFramework.Data;
using ASP_Razor_EntityFramework.Models;

namespace ASP_Razor_EntityFramework.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly ASP_Razor_EntityFramework.Data.ArticleContext _context;

        public IndexModel(ASP_Razor_EntityFramework.Data.ArticleContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        // Chuỗi để tìm kiếm, được binding tự động kể cả là truy 
        // cập get
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {

            // Truy vấn lấy các Article
            var articles = from a in _context.Article select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Console.WriteLine(SearchString);
                // Truy vấn lọc các Article mà tiêu đề chứa chuỗi tìm kiếm
                articles = articles.Where(article => article.Title.Contains(SearchString));
            }
            // Đọc (nạp) Article
            Article = await articles.ToListAsync();
        }
    }
}
