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
            public string EtiquetaCheque { get; set; }
            public int ValorCheque { get; set; }
            public int CantidadCheque { get; set; }
        }

        private ConfiguracionCheques_V2 _configuracion = new ConfiguracionCheques_V2();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? cantidad, string? prioriza1, string? prioriza2, string? prioriza3)
        {
            Cheques = new List<CantidadCheques>();
            if (cantidad.HasValue)
            {
                Configuracion.Reprioriza(prioriza1, prioriza2, prioriza3);


                CheckCounter = new ContadorDeCheques(Configuracion);
                CheckCounter.Cantidad = cantidad.Value;
                CheckCounter.Cuenta_V2();
                Dictionary<int, int> resultado = CheckCounter.Resultado;
                foreach (var item in resultado)
                {
                    CantidadCheques cc = new CantidadCheques();
                    cc.EtiquetaCheque = item.Key.ToString() + "€";
                    cc.ValorCheque = item.Key;
                    cc.CantidadCheque = item.Value;
                    Cheques.Add(cc);
                }

            }
            else
            {

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
                return RedirectToPage("Index", new { cantidad = Cantidad });
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public int Cantidad { get; set; }

        [BindProperty]
        public ContadorDeCheques CheckCounter { get; set; }
        [BindProperty]
        public List<CantidadCheques> Cheques { get; set; }
        [BindProperty]
        public ConfiguracionCheques_V2 Configuracion
        {
            get { return _configuracion; }
        }


        [BindProperty]
        public int ValorMochila 
        {
            get
            {
                int valor = 0;
                foreach (CantidadCheques cheques in Cheques)
                {
                    valor += cheques.ValorCheque * cheques.CantidadCheque;

                }
                return valor;
            }
        }
    }
}
