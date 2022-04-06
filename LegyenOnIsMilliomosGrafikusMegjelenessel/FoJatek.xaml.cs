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
        private List<int> ertekek;
        private Random rnd;
        private int valasztottKerdes;

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
            this.ertekek = new List<int>();
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
            this.ertekek.Add(5000);
            this.ertekek.Add(10000);
            this.ertekek.Add(25000);
            this.ertekek.Add(50000);
            this.ertekek.Add(100000);
            this.ertekek.Add(200000);
            this.ertekek.Add(300000);
            this.ertekek.Add(500000);
            this.ertekek.Add(800000);
            this.ertekek.Add(1500000);
            this.ertekek.Add(3000000);
            this.ertekek.Add(5000000);
            this.ertekek.Add(10000000);
            this.ertekek.Add(20000000);
            this.ertekek.Add(40000000);
        }

        private void JatekosElkeszitese()
        {
            this.gamer = new Jatekos(NevAdas.nev);
        }

        private void KerdesElkeszitese()
        {
            valasztottKerdes = rnd.Next(0, kerdesek[gamer.JatekosSzint].SorKerdesLista.Count); 
            Keret.Content = gamer.JatekosSzint + ". kérdés, ami " + ertekek[gamer.JatekosSzint-1] + " ft-os. Témakör: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Temakor ;
            lbl_kerdes.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Kerdes;
            btn_a.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[0];
            btn_b.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[1];
            btn_c.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[2];
            btn_d.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[3];
        }

        private void btn_valasz_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Tag.Equals(kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs))
            {
                FoJatek j = new FoJatek();
                MessageBox.Show("Gratulálok a válaszod helyes, folytathatod a játékot.", "Információ",MessageBoxButton.OK,MessageBoxImage.Information);
                this.gamer.JatekosSzint++;
                this.Hide();
                j.Show();
            }
            else
            {
                MainWindow m = new MainWindow();
                MessageBox.Show("Sajnáljuk a válaszod helytelen, játékod véget ért.", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                m.Show();
            }
        }
    }
}
