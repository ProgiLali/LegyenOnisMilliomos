using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    class SorKerdesek
    {
        private List<SorKerdes> sorKerdesLista;

        public SorKerdesek(string nev)
        {
            Feltoltes(nev);
        }

        public SorKerdesek()
        {
            sorKerdesLista = new List<SorKerdes>();
        }

        internal List<SorKerdes> SorKerdesLista { get => sorKerdesLista; set => sorKerdesLista = value; }

        private void Feltoltes(string nev)
        {
            sorKerdesLista = new List<SorKerdes>();
            StreamReader be = new StreamReader(nev);
            while (!be.EndOfStream)
            {
                sorKerdesLista.Add(new SorKerdes(be.ReadLine()));
            }
            be.Close();
        }

    }
}
