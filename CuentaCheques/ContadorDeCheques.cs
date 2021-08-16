using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaCheques
{
    public class ContadorDeCheques
    {

        public ContadorDeCheques(ConfiguracionCheques_V2 config= null)
        {
            if (config == null)
                this.config = new ConfiguracionCheques_V2();
            else
                this.config = config;



        }
        public int Cantidad { get; set; }

        public class Item
        {
            public int Weight { get; set; }
            public int Value { get; set; }
        }

        public int[] Mochila(int cantidad, Item[] items)
        {

            int[] mochila = new int[items.Length];
            int[] mochilaCandidata = new int[items.Length];
            MochilaRec(cantidad, 0, items, mochila, mochilaCandidata);
            return mochila;


        }
        public bool MochilaRec(int cantidad, int nivel, Item[] items, int[] mochila, int[] mochilaCandidata)
        {
            if (nivel == items.Length)
            {
                int pesoMCand = PesoMochila(mochilaCandidata, items);
                int pesoM = PesoMochila(mochila, items);
                if (pesoMCand > pesoM)
                {
                    Array.Copy(mochilaCandidata, mochila, mochilaCandidata.Length);
                }
                else if (pesoMCand == pesoM)
                {
                    if (ChequesMochila(mochilaCandidata, items) < ChequesMochila(mochila, items))
                    {
                        Array.Copy(mochilaCandidata, mochila, mochilaCandidata.Length);
                    }

                }
                return true;

            }
            else
            {
                int pesoActual = PesoMochila(mochilaCandidata, items);

                int maxCheques = (cantidad - pesoActual) / items[nivel].Weight;
                for (int nCheques = 0; nCheques <= maxCheques; nCheques++)
                {
                    if (nivel == 0)
                    {
                        Debug.Print("");
                    }
                    ResetMochila(nivel, mochilaCandidata);
                    mochilaCandidata[nivel] = nCheques;
                    MochilaRec(cantidad, nivel + 1, items, mochila, mochilaCandidata);

                }
                return true;
            }

        }

        private void ResetMochila(int nivel, int[] mochila)
        {
            for (int i = nivel; i < mochila.Length; i++)
            {
                mochila[i] = 0;
            }
        }

        private int ValorMochila(int[] mochila, Item[] items)
        {
            int valor = 0;            
            for (int i = 0; i < mochila.Length; i++)
            {
                valor += mochila[i] * items[i].Value;            
            }
            return valor;
            
        }

        private int ChequesMochila(int[] mochila, Item[] items)
        {
            
            int numCheques = 0;
            for (int i = 0; i < mochila.Length; i++)
            {
            
                numCheques += mochila[i];
            }            
            return numCheques;
        }

        private int PesoMochila(int[] mochila, Item[] items)
        {
            int peso = 0;
            for (int i = 0; i < mochila.Length; i++)
            {
                peso += mochila[i] * items[i].Weight;
            }
            return peso;
        }
        private void PrintMochila(int[] mochila, Item[] items)
        {
            int peso = 0;
            int valor = 0;
            for (int i = 0; i < mochila.Length; i++)
            {
                peso += mochila[i] * items[i].Weight;
                valor += mochila[i] * items[i].Value;
                Console.WriteLine("Cheques de {0}: {1}", items[i].Weight, mochila[i]);
            }
            Console.WriteLine("Cantidad: {0}, Valor {1}", peso, valor);
        }

        public void Cuenta()
        {
            
            Item[] items = new Item[]{
                new Item {Value = config.Cheque1Peso, Weight = config.Cheque1Peso},
                new Item {Value = config.Cheque2Peso, Weight = config.Cheque2Peso},
                new Item {Value = config.Cheque3Peso, Weight = config.Cheque3Peso},

            };
            
            
            int[] mochila = Mochila(Cantidad, items);
            //PrintMochila(mochila, items);
            Resultado = new Dictionary<int, int>();
            for (int i=0; i< mochila.Length; i++)
            {
                Resultado[items[i].Weight] = mochila[i];
            }

        }

        public Dictionary<int, int> Resultado { get; set; }
        private ConfiguracionCheques_V2 config;

    }
}
