using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaCheques.Pages
{
    public class IndexModel : PageModel
    {

        public class CantidadCheques
        {
            public int ValorCheque { get; set; }
            public int CantidadCheque { get; set; }
        }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? cantidad)
        {
            Cheques = new List<CantidadCheques>();
            if (cantidad.HasValue)
            {
                
                CheckCounter = new ContadorDeCheques();
                CheckCounter.Cantidad = cantidad.Value;
                CheckCounter.Cuenta();
                Dictionary<int, int> resultado = CheckCounter.Resultado;
                foreach (var item in resultado)
                {
                    CantidadCheques cc = new CantidadCheques();
                    cc.ValorCheque = item.Key;
                    cc.CantidadCheque = item.Value;
                    Cheques.Add(cc);
                }

            }

          
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
          /*      Cheques.Clear();
                CheckCounter.Cuenta();
                Dictionary<int, int> resultado=  CheckCounter.Resultado;
                foreach (var item in resultado)
                {
                    CantidadCheques cc = new CantidadCheques();
                    cc.ValorCheque = item.Key;
                    cc.CantidadCheque = item.Value;
                    Cheques.Add(cc);
                }*/
                return RedirectToPage("Index", new { cantidad = Cantidad});
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public int Cantidad{ get; set; }

        [BindProperty]
        public ContadorDeCheques CheckCounter { get; set; }
        [BindProperty]
        public List<CantidadCheques> Cheques { get; set; }
    }
}
