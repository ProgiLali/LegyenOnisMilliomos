using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    class SorKerdes
    {
        //Tegye az alábbi növényeket virágzási idejük kezdete szerint időrendbe!;ibolya;rózsa;orgona;őszi rózsa;ACBD;BIOLÓGIA
        private string kerdes;
        private List<string> valaszok;
        private string valaszkulcs;
        private string temakor;

        public SorKerdes(string sor)
        {
            string[] reszek = sor.Split(';');
            this.kerdes = reszek[0];
            this.valaszok = new List<string>();
            for (int i = 1; i < 5; i++)
            {
                this.valaszok.Add(reszek[i]);
            }
            this.valaszkulcs = reszek[5];
            this.temakor = reszek[6];
        }

        public SorKerdes(string kerdes,string valasz1,string valasz2,string valasz3, string valasz4,string valaszkulcs,string temakor)
        {
            this.kerdes = kerdes;
            this.valaszok = new List<string>();
            this.valaszok.Add(valasz1);
            this.valaszok.Add(valasz2);
            this.valaszok.Add(valasz3);
            this.valaszok.Add(valasz4);
            this.valaszkulcs = valaszkulcs;
            this.temakor = temakor;
        }

        public string Kerdes { get => kerdes; set => kerdes = value; }
        public List<string> Valaszok { get => valaszok; set => valaszok = value; }
        public string Valaszkulcs { get => valaszkulcs; set => valaszkulcs = value; }
        public string Temakor { get => temakor; set => temakor = value; }
    }
}
