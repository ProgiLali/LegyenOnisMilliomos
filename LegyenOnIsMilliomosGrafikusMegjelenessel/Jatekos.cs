using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    class Jatekos
    {
        private string nev;
        private int jatekosSzint;

        public Jatekos(string nev) 
        {
            this.nev = nev;
            this.jatekosSzint = 1;
        }

        public string Nev { get => nev; set => nev = value; }
        public int JatekosSzint { get => jatekosSzint; set => jatekosSzint = value; }
    }
}
