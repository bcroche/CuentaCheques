using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaCheques
{
    public class ConfiguracionCheques_V2
    {
        public ConfiguracionCheques_V2()
        {
            Cheque1Valor = true;
            Cheque2Valor = true;
            Cheque3Valor = true;
            Cheque1Peso = 8;
            Cheque2Peso = 3;
            Cheque3Peso = 2;
        }


        public bool Cheque1Valor { get; set; }
        public bool Cheque2Valor { get; set; }
        public bool Cheque3Valor { get; set; }

        public int Cheque1Peso { get; set; }
        public int Cheque2Peso { get; set; }
        public int Cheque3Peso { get; set; }

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
            int n = 0;
            if (Cheque1Valor) n++;
            if (Cheque2Valor) n++;
            if (Cheque3Valor) n++;

            return n;
        }
    }
}
