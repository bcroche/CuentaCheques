using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequesAndroid
{
    class BasicMochila
    {
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
                    if (ValorMochila(mochilaCandidata, items) > ValorMochila(mochila, items))
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
                        //Debug.Print("");
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

        public void Run()
        {
            Item[] items = new Item[]{
                new Item {Value = 8, Weight = 8},
                new Item {Value = 1, Weight = 2},
                new Item {Value = 1, Weight = 3},

            };
            int objetivo = 0;
            Console.Write("Objetivo: ");
            string s = Console.ReadLine();
            objetivo = int.Parse(s);
            int[] mochila = Mochila(objetivo, items);
            PrintMochila(mochila, items);

        }
    }
}