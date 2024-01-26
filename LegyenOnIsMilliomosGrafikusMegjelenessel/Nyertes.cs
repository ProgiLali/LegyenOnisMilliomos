using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    class Nyertes : Jatekos
    {
        private int nyeremeny;

        public Nyertes(string jatekos, int jatekosSzint, int nyeremeny) : base(jatekos,jatekosSzint)
        {
            this.nyeremeny = nyeremeny;
        }

        public int Nyeremeny { get => nyeremeny; set => nyeremeny = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}",this.nev,this.JatekosSzint,this.nyeremeny);
        }
    }
}
