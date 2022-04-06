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
    /// Interaction logic for NevAdas.xaml
    /// </summary>
    public partial class NevAdas : Window
    {
        public static string nev;

        public NevAdas()
        {
            InitializeComponent();
        }

        private void btn_tovabb_Click(object sender, RoutedEventArgs e)
        {
            nev = txb_nev.Text.ToString();
            if (!nev.Equals(""))
            {
                FoJatek f = new FoJatek();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Nem adtad meg a nevedet!", "Hiányos név", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
