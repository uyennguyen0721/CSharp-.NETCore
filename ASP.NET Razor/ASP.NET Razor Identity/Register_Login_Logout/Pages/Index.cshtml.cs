using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Register_Login_Logout.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register_Login_Logout.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbcontext)
        {
            _logger = logger;
            _dbContext = dbcontext;
        }

        public void OnGet()
        {

        }
        public void OnGetDeleteDb()
        {
            _logger.LogInformation("Xóa DB");
            _dbContext.Database.EnsureDeleted();
        }
    }
}
