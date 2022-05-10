using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaCheques
{
    public class ConfiguracionCheques_V2
    {
        public class TipoCheque
        {
            public TipoCheque(bool _active, int _weight)
            {
                Weight = _weight;
                Active = _active;

            }
            public int Weight { get; set; }
            public bool Active { get; set; }
        }

        TipoCheque[] tiposDeCheque= new TipoCheque[4];
        public ConfiguracionCheques_V2()
        {
            tiposDeCheque[0] = new TipoCheque(true, 8);
            tiposDeCheque[1] = new TipoCheque(true, 6);
            tiposDeCheque[2] = new TipoCheque(true, 3);
            tiposDeCheque[3] = new TipoCheque(true, 2);

            
        }


        public bool Cheque1Valor { get; set; }
        public bool Cheque2Valor { get; set; }
        public bool Cheque3Valor { get; set; }

        public int Cheque1Peso { get; set; }
        public int Cheque2Peso { get; set; }
        public int Cheque3Peso { get; set; }
        public TipoCheque[] TiposDeCheque { get => tiposDeCheque; set => tiposDeCheque = value; }

        internal void Reprioriza(string prioriza1, string prioriza2, string prioriza3)
        {
            if (prioriza1=="on")
            {
                Cheque1Valor = true;
            }
            else
            {
                Cheque1Valor = false;
            }
            if (prioriza2 == "on")
            {
                Cheque2Valor = true;
            }
            else
            {
                Cheque2Valor = false;
            }
            if (prioriza3 == "on")
            {
                Cheque3Valor = true;
            }
            else
            {
                Cheque3Valor = false;
            }
        }

        internal int ChequesDistintos()
        {
            /*
            int n = 0;
            if (Cheque1Valor) n++;
            if (Cheque2Valor) n++;
            if (Cheque3Valor) n++;
            */
            return tiposDeCheque.Length;
        }
    }
}
