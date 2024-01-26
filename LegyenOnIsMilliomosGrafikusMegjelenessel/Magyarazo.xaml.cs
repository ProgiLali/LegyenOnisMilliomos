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
    /// Interaction logic for Magyarazo.xaml
    /// </summary>
    public partial class Magyarazo : Window
    {
        public Magyarazo()
        {
            InitializeComponent();
        }

        private void btn_vissza_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }

        private void lbl_leiras_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_leiras.Content = "A Legyen ön is Milliomos játék szabályai és céljai:" +
                "\n\t- Elöszőr is a sorkérdésre helyesen kell válaszolnod hogy bejuss a játékba." +
                "\n\t- Ha bejutottál elkezdödhet a játék ahol 15 kérdésre kell helyesen válaszolnod a főnyereményért." +
                "\n\t- Kezdetben 2 segítség áll rendelkezésedre: a válaszok felezése és a közönség segítség." +
                "\n\t- Minden telejesített kérdés után megálhatsz a biztos nyereményeddel akár a következő kérdés közben is.";

            if (MainWindow.ujjatek)
            {
                lbl_ujJatek.Visibility = Visibility.Visible;
                btn_ujJatek.Visibility = Visibility.Visible;
            }
        }

        private void btn_ujJatek_Click(object sender, RoutedEventArgs e)
        {
            Jatek j = new Jatek();
            this.Hide();
            j.Show();
        }
    }
}
