using System;
using System.Collections.Generic;
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
    /// Interaction logic for Jatek.xaml
    /// </summary>
    public partial class Jatek : Window
    {
        private SorKerdesek kerdes;
        private Random Rnd;
        private int index;
        private string sorrend;

        public Jatek()
        {
            InitializeComponent();
            Feltoltes();
        }

        private void Feltoltes()
        {
            kerdes = new SorKerdesek("sorkerdes.txt");
            Rnd = new Random();
            index = Rnd.Next(0, kerdes.SorKerdesLista.Count);
            lbl_kerdes.Content = kerdes.SorKerdesLista[index].Kerdes + "\n" + kerdes.SorKerdesLista[index].Valaszkulcs;
            Keret.Header = kerdes.SorKerdesLista[index].Temakor;
            btn_a.Content = "A: " + kerdes.SorKerdesLista[index].Valaszok[0];
            btn_b.Content = "B: " + kerdes.SorKerdesLista[index].Valaszok[1];
            btn_c.Content = "C: " + kerdes.SorKerdesLista[index].Valaszok[2];
            btn_d.Content = "D: " + kerdes.SorKerdesLista[index].Valaszok[3];
            this.sorrend = "";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.IsEnabled = false;
            lbl_valasz.Content += " " + b.Tag;
            this.sorrend += b.Tag; 
        }

        private void btn_torol_Click(object sender, RoutedEventArgs e)
        {
            btn_a.IsEnabled = true;
            btn_b.IsEnabled = true;
            btn_c.IsEnabled = true;
            btn_d.IsEnabled = true;
            lbl_valasz.Content = "A választott Sorrended:";
            this.sorrend = "";
        }

        private void btn_tovabb_Click(object sender, RoutedEventArgs e)
        {
            if(this.sorrend.Length == 4)
            {
                if (this.sorrend.Equals(kerdes.SorKerdesLista[index].Valaszkulcs))
                {
                    NevAdas n = new NevAdas();
                    MessageBox.Show("Gratulálok, bejutottál a játékba.", "Gratuláció", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    n.Show();
                }
                else
                {
                    MainWindow m = new MainWindow();
                    MessageBox.Show("Sajnáljuk, a válaszod helytelen lett, most visszaküldünk a főmenübe.", "Továbbjutás", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    m.Show();
                }
            }
            else
            {
                MessageBox.Show("A válaszod hibás, nem használtad fel az összes válaszodat!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
