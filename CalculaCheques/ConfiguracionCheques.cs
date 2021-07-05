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
            Cheque2Valor = 3;
            Cheque3Valor = 2;
            Cheque1Peso = 8;
            Cheque2Peso = 1;
            Cheque3Peso = 1;
        }


        public int Cheque1Valor { get; set; }
        public int Cheque2Valor { get; set; }
        public int Cheque3Valor { get; set; }

        public int Cheque1Peso { get; set; }
        public int Cheque2Peso { get; set; }
        public int Cheque3Peso { get; set; }
    }
}
