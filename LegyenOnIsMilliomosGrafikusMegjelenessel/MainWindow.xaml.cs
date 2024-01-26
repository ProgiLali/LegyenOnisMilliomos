using LegyenOnIsMilliomosGrafikusMegjelenessel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegyenOnIsMilliomosGrafikusMegjelenessel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool ujjatek;


        public MainWindow()
        {
            InitializeComponent();
        }



        private void btn_ujJatek_Click(object sender, RoutedEventArgs e)
        {
            ujjatek = true;
            MagyarazoMegjelenites();
        }

        private void btn_informacio_Click(object sender, RoutedEventArgs e)
        {
            ujjatek = false;
            MagyarazoMegjelenites();
        }

        private void MagyarazoMegjelenites()
        {
            Magyarazo m = new Magyarazo();
            this.Hide();
            m.Show();
        }

        private void btn_dicsoseg_Click(object sender, RoutedEventArgs e)
        {
            DicsosegLista.dicsoseg = true;
            DicsAblakMeghivasa();
        }

        private void btn_betoltes_Click(object sender, RoutedEventArgs e)
        {
            DicsosegLista.dicsoseg = false;
            DicsAblakMeghivasa();
        }

        private void DicsAblakMeghivasa()
        {
            DicsosegLista d = new DicsosegLista();
            this.Hide();
            d.Show();
        }
    }
}
