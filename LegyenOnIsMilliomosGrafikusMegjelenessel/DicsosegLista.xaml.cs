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
    /// Interaction logic for DicsosegLista.xaml
    /// </summary>
    public partial class DicsosegLista : Window
    {
        public static bool dicsoseg;
        private List<Jatekos> lista; 

        public DicsosegLista()
        {
            InitializeComponent();
            if (dicsoseg)
            {
                RanglistaFeltolt("legjobbak.txt");
                btn_betoltes.Visibility = Visibility.Hidden;
            }
            else
            {
                lista = new List<Jatekos>();
                this.Title = "Legyen Ön is Milliomos játék mentett játékai";
                lbl_szoveg.Content = "Mentett játék állások:";
                lista = new List<Jatekos>();
                RanglistaFeltolt("Mentesek.txt");
            }
        }

        private void RanglistaFeltolt(string nev)
        {

            StreamReader be = new StreamReader(nev);
            int i = 1;
            while (!be.EndOfStream)
            {
                string[] reszek = be.ReadLine().Split(';');
                if (dicsoseg)
                {
                    lbox_nevek.Items.Add(string.Format("{0}. {1} aki teljesített {2}. kérdést és a nyereménye {3:N0} forint volt.",
                        i, reszek[0], reszek[1], int.Parse(reszek[2])));
                }
                else
                {
                    lista.Add(new Jatekos(reszek[0], int.Parse(reszek[1]), bool.Parse(reszek[2]), bool.Parse(reszek[3])));
                    lbox_nevek.Items.Add(i + ". " + lista[i-1].Kiiras());
                }
                i++;
            }
            be.Close();
        }

        private void btn_fomenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }
    }
}
