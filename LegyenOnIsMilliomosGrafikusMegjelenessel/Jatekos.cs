using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    class Jatekos
    {
        protected string nev;
        protected int jatekosSzint;
        protected bool felezes;
        protected bool kozonseg;

        public Jatekos(string nev) 
        {
            this.nev = nev;
            this.jatekosSzint = 1;
            this.felezes = false;
            this.kozonseg = false;
        }

        public Jatekos(string nev, int jatekosSzint)
        {
            this.nev = nev;
            this.jatekosSzint = jatekosSzint;
        }

        public Jatekos(string nev, int jatekosSzint, bool felezes, bool kozonseg)
        {
            this.nev = nev;
            this.jatekosSzint = jatekosSzint;
            this.felezes = felezes;
            this.kozonseg = kozonseg;
        }

        public string Nev { get => nev; set => nev = value; }
        public int JatekosSzint { get => jatekosSzint; set => jatekosSzint = value; }
        public bool Felezes { get => felezes; set => felezes = value; }
        public bool Kozonseg { get => kozonseg; set => kozonseg = value; }

        public string Kiiras()
        {
            if(this.felezes && this.kozonseg)
            {
                return string.Format("{0} aki a {1} és {2} kérdés között jár, és elhasznált minden segítséget.",
                    this.nev,this.jatekosSzint,this.jatekosSzint+1);
            }
            if (this.felezes || this.kozonseg)
            {
                return string.Format("{0} aki a {1} és {2} kérdés között jár, és megvan a {3} segítsége.",
                    this.nev, this.jatekosSzint, this.jatekosSzint + 1,this.felezes?"közönség":"felezés");
            }
            else
            {
                return string.Format("{0} aki a {1} és {2} kérdés között jár, és megvan minden segitsége.",
                    this.nev, this.jatekosSzint, this.jatekosSzint + 1);
            }
        }

        public override string ToString()
        {
            return string.Format("{0};{1}",this.nev,this.jatekosSzint);
        }
    }
}
