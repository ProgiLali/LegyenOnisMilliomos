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
        public static string nev;
        private List<SorKerdesek> kerdesek;
        private Jatekos gamer;
        private List<int> ertekek;
        private Random rnd;
        private int valasztottKerdes;
        private bool voltFelezes;

        public FoJatek()
        {
            InitializeComponent();
            Feltoltes();
            JatekosElkeszitese();
            KerdesElkeszitese();
        }

        private void Feltoltes()
        {
            this.voltFelezes = false;
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
            this.ertekek.Add(0);
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
            this.gamer = new Jatekos(nev);
        }

        private void KerdesElkeszitese()
        {
            valasztottKerdes = rnd.Next(0, kerdesek[gamer.JatekosSzint].SorKerdesLista.Count);
            string kerdes = string.Format("{0}.kérdés, aminek az értéke: {1:N0} forint. Témakör: {2}",
                gamer.JatekosSzint, ertekek[gamer.JatekosSzint],kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Temakor);
            Keret.Content = kerdes;
            lbl_kerdes.Content = kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Kerdes + "\n" + 
                kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs;
            btn_a.Content = "A: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[0];
            btn_b.Content = "B: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[1];
            btn_c.Content = "C: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[2];
            btn_d.Content = "D: " + kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszok[3];
        }

        private void btn_valasz_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Tag.Equals(kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs))
            {
                string text = "Következő kérdés";
                MessageBox.Show("Gratulálok a válaszod helyes.", "Információ",MessageBoxButton.OK,MessageBoxImage.Information);

                Keret.Visibility = Visibility.Hidden;
                lbl_kerdes.Visibility = Visibility.Hidden;
                btn_a.Visibility = Visibility.Hidden;
                btn_b.Visibility = Visibility.Hidden;
                btn_c.Visibility = Visibility.Hidden;
                btn_d.Visibility = Visibility.Hidden;
                lbl_segit.Visibility = Visibility.Hidden;
                btn_felezes.Visibility = Visibility.Hidden;
                btn_kozonseg.Visibility = Visibility.Hidden;
                btn_kiszallas.Visibility = Visibility.Hidden;
                this.gamer.JatekosSzint++;
                if(gamer.JatekosSzint == 16)
                {
                    FoNyeremeny();
                }
                else if (gamer.JatekosSzint > 5 && gamer.JatekosSzint < 11)
                {
                    text += ", biztos nyeremény 100 000 ft";
                }
                else if (gamer.JatekosSzint > 10)
                {
                    text += ", biztos nyeremény 1 500 000 ft";
                }
                btn_kovetkezoKerdes.Content = text;
                lbl_uzenet.Visibility = Visibility.Visible;
                btn_kilepes.Content = string.Format("Játék befejezése {0:N0} ft-tal.", ertekek[gamer.JatekosSzint - 1]);
                btn_kovetkezoKerdes.Visibility = Visibility.Visible;
                btn_kilepes.Visibility = Visibility.Visible;
            }
            else
            {
                if(gamer.JatekosSzint > 5 && gamer.JatekosSzint < 11)
                {
                    RosszValaszNyeremeny(100000);
                }
                else if(gamer.JatekosSzint > 10)
                {
                    RosszValaszNyeremeny(1500000);
                }
                else
                {
                    MainWindow m = new MainWindow();
                    MessageBox.Show("Sajnáljuk a válaszod helytelen, nem nyertél semmit.....", "Információ", MessageBoxButton.OK);
                    this.Hide();
                    m.Show();
                }

            }
        }

        private void FoNyeremeny()
        {
            MessageBox.Show("Gratulálok, megnyerted a főnyereményt a 40 millió forintot. Nevedet felírjuk a legjobbak közé.", "Örület", 
                MessageBoxButton.OK);
            DicsosegListaSzerk(gamer.Nev,15,ertekek[14]);
            DicsosegAtlepes();
        }

        private void btn_kovetkezoKerdes_Click(object sender, RoutedEventArgs e)
        {
            KerdesElkeszitese();
            voltFelezes = false;
            lbl_uzenet.Visibility = Visibility.Hidden;
            btn_kovetkezoKerdes.Visibility = Visibility.Hidden;
            btn_kilepes.Visibility = Visibility.Hidden;
            Keret.Visibility = Visibility.Visible;
            lbl_kerdes.Visibility = Visibility.Visible;
            btn_a.IsEnabled = true;
            btn_a.Visibility = Visibility.Visible;
            btn_b.IsEnabled = true;
            btn_b.Visibility = Visibility.Visible;
            btn_c.IsEnabled = true;
            btn_c.Visibility = Visibility.Visible;
            btn_d.IsEnabled = true;
            btn_d.Visibility = Visibility.Visible;
            lbl_segit.Visibility = Visibility.Visible;
            btn_kiszallas.Visibility = Visibility.Visible;
            btn_felezes.Visibility = Visibility.Visible;
            if (gamer.Felezes)
            {
                btn_felezes.IsEnabled = false;
            }
            btn_kozonseg.Visibility = Visibility.Visible;
            if (gamer.Kozonseg)
            {
                btn_kozonseg.IsEnabled = false;
            }
        }

        private void btn_kilepes_Click(object sender, RoutedEventArgs e)
        {
            if (gamer.JatekosSzint > 1)
            {
                string t = "Gratulálok a nyereményedhez, ami " + ertekek[gamer.JatekosSzint - 1] + "ft. Nevedet felírtuk a Dícsőség listára.";
                MessageBox.Show(t, "Gratuláció", MessageBoxButton.OK, MessageBoxImage.Information);
                DicsosegListaSzerk(gamer.Nev, gamer.JatekosSzint - 1, ertekek[gamer.JatekosSzint - 1]);
                DicsosegAtlepes();
            }
            else
            {
                MainWindow m = new MainWindow();
                MessageBox.Show("Sajnáljuk hogy ilyen hamar befejezed a megmérettetést, de ha te így látod jónak....."
                    , "Információ", MessageBoxButton.OK);
                this.Hide();
                m.Show();
            }
        }

        private void btn_felezes_Click(object sender, RoutedEventArgs e)
        {
            voltFelezes = true;
            gamer.Felezes = true;
            btn_felezes.IsEnabled = false;
            string[] valaszok = new string[4] { "A", "B", "C", "D" };
            List<string> valasztas2 = new List<string>();
            int i = 0;
            while(i < 2)
            {
                int veletlen = rnd.Next(0, 4);
                if (!valaszok[veletlen].Equals(kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs))
                {
                    int j = 0;
                    while(j < valasztas2.Count && valasztas2[j] != valaszok[veletlen])
                    {
                        j++;
                    }
                    if (j == valasztas2.Count)
                    {
                        valasztas2.Add(valaszok[veletlen]);
                        i++;
                    }
                    
                }
            }
            List<Button> gombok = ValaszGombok();
            for (i = 0; i < gombok.Count; i++)
            {
                for (int j = 0; j < valasztas2.Count; j++)
                {
                    if (gombok[i].Tag.Equals(valasztas2[j]))
                    {
                        gombok[i].IsEnabled = false;
                    }
                }
            }
        }

        private void btn_kozonseg_Click(object sender, RoutedEventArgs e)
        {
            gamer.Kozonseg = true;
            btn_kozonseg.IsEnabled = false;
            if (voltFelezes)
            {
                List<Button> gombok = ValaszGombok();
                List<Button> meglevoGombok = new List<Button>();
                foreach (var item in gombok)
                {
                    if (item.IsEnabled)
                    {
                        meglevoGombok.Add(item);
                    }
                }
                int ossz = 100;
                bool egyszeri = true;
                int i = 0;
                int[] aranyok = new int[2] { 0, 0 };
                while (ossz > 0)
                {
                    if (meglevoGombok[i].Equals(kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs) && egyszeri)
                    {
                        aranyok[i] += 40;
                        ossz -= 40;
                        egyszeri = false;
                    }
                    int gen = rnd.Next(0, 21);
                    if ((ossz - gen) >= 0)
                    {
                        aranyok[i] += gen;
                        ossz -= gen;
                    }
                    i++;
                    if (i == meglevoGombok.Count)
                    {
                        i = 0;
                    }
                }
                for (i = 0; i < meglevoGombok.Count; i++)
                {
                    meglevoGombok[i].Content += ": " + aranyok[i];
                }
            }
            else
            {
                string[] index = new string[4] { "A", "B", "C", "D" };
                int[] aranyok = new int[4] { 0, 0, 0, 0 };
                bool egyszeri = true;
                int ossz = 100;
                int i = 0;
                while (ossz > 0)
                {
                    if (index[i].Equals(kerdesek[gamer.JatekosSzint].SorKerdesLista[valasztottKerdes].Valaszkulcs) && egyszeri)
                    {
                        aranyok[i] += 40;
                        ossz -= 40;
                        egyszeri = false;
                    }
                    int gen = rnd.Next(0, 21);
                    if ((ossz - gen) >= 0)
                    {
                        aranyok[i] += gen;
                        ossz -= gen;
                    }
                    i++;
                    if (i == index.Length)
                    {
                        i = 0;
                    }
                }
                List<Button> gombok = ValaszGombok();
                for (i = 0; i < gombok.Count; i++)
                {
                    gombok[i].Content += ": " + aranyok[i];
                }
            }
        }

        private List<Button> ValaszGombok()
        {
            List<Button> gombok = new List<Button>();
            gombok.Add(btn_a);
            gombok.Add(btn_b);
            gombok.Add(btn_c);
            gombok.Add(btn_d);
            return gombok;
        }

        private void DicsosegListaSzerk(string nev,int teljesítettSzint,int nyeremeny)
        {
            List<Nyertes> lista = new List<Nyertes>();
            StreamReader be = new StreamReader("legjobbak.txt");
            while (!be.EndOfStream)
            {
                string[] reszek = be.ReadLine().Split(';');
                lista.Add(new Nyertes(reszek[0], int.Parse(reszek[1]),int.Parse(reszek[2])));
            }
            be.Close();
            lista.Add(new Nyertes(nev,teljesítettSzint,nyeremeny));
            int i = 15;
            List<Nyertes> ujLista = new List<Nyertes>();
            while (i > 0)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (i == lista[j].JatekosSzint)
                    {
                        ujLista.Add(lista[j]);
                    }
                }
                i--;
            }
            StreamWriter ki = new StreamWriter("legjobbak.txt");
            foreach (var item in ujLista)
            {
                ki.WriteLine(item.ToString());
            }
            ki.Close();
        }

        private void DicsosegAtlepes()
        {
            DicsosegLista d = new DicsosegLista();
            this.Hide();
            d.Show();
        }

        private void RosszValaszNyeremeny(int nyeremeny)
        {
            DicsosegListaSzerk(gamer.Nev, gamer.JatekosSzint-1, nyeremeny);
            string text = "Sajnáljuk a válaszod helytelen, de nyertél " + nyeremeny + " forintot és a neved felkerül a dícsőség listára.";
            MessageBox.Show(text,"Információ", MessageBoxButton.OK);
            DicsosegAtlepes();
        }

    }
}
