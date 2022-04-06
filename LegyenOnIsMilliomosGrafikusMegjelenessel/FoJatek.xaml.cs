using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    /// <summary>
    /// Interaction logic for FoJatek.xaml
    /// </summary>
    public partial class FoJatek : Window
    {
        private List<SorKerdesek> kerdesek;
        private Jatekos gamer;
        private int[] ertekek;
        private Random rnd;

        public FoJatek()
        {
            InitializeComponent();
            Feltoltes();
            JatekosElkeszitese();
            KerdesElkeszitese();
        }

        private void Feltoltes()
        {
            this.kerdesek = new List<SorKerdesek>();
            for (int i = 0; i < 16; i++)
            {
                this.kerdesek.Add(new SorKerdesek());
            }
            StreamReader be = new StreamReader("kerdes.txt");
            while (!be.EndOfStream)
            {
                string[] reszek = be.ReadLine().Split(';');
                kerdesek[int.Parse(reszek[0])].SorKerdesLista.Add(new SorKerdes(reszek[1], reszek[2], reszek[3], reszek[4], reszek[5], reszek[6], reszek[7]));
            }
            be.Close();
            rnd = new Random();
        }

        private void JatekosElkeszitese()
        {
            this.gamer = new Jatekos(NevAdas.nev);
        }

        private void KerdesElkeszitese()
        {
            int i = rnd.Next(0, kerdesek[gamer.JatekosSzint].SorKerdesLista.Count); 
            Keret.Content = gamer.JatekosSzint + ". kérdés: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Temakor;
            lbl_kerdes.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Kerdes;
            btn_a.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Valaszok[0];
            btn_b.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Valaszok[1];
            btn_c.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Valaszok[2];
            btn_d.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[i].Valaszok[3];
        }
    }
}
