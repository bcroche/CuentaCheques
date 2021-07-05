using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CuentaCheques.Pages
{
    public class homeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public homeModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //CheckCounter = new ContadorDeCheques();

        }

        [BindProperty]
        public ContadorDeCheques CheckCounter { get; set; }

        
    }
}
