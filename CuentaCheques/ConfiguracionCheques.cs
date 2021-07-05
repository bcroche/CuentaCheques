using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaCheques
{
    public class ConfiguracionCheques
    {
        public ConfiguracionCheques()
        {
            Cheque1Valor = 8;
            Cheque2Valor = 1;
            Cheque3Valor = 1;
            Cheque1Peso = 8;
            Cheque2Peso = 3;
            Cheque3Peso = 2;
        }


        public int Cheque1Valor { get; set; }
        public int Cheque2Valor { get; set; }
        public int Cheque3Valor { get; set; }

        public int Cheque1Peso { get; set; }
        public int Cheque2Peso { get; set; }
        public int Cheque3Peso { get; set; }

        internal void Reprioriza(string prioriza1, string prioriza2, string prioriza3)
        {
            if (prioriza1=="on")
            {
                Cheque1Valor = 8;
            }
            else
            {
                Cheque1Valor = 1;
            }
            if (prioriza2 == "on")
            {
                Cheque2Valor = 8;
            }
            else
            {
                Cheque2Valor = 1;
            }
            if (prioriza3 == "on")
            {
                Cheque3Valor = 8;
            }
            else
            {
                Cheque3Valor = 1;
            }
        }
    }
}
