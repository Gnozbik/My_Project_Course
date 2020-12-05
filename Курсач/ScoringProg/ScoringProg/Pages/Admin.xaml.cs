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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScoringProg.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GlavEcran.xaml", UriKind.Relative));

        }

        private void bt_ProverkaZaivky_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Zaivky.xaml", UriKind.Relative));

        }

        private void bt_ProcmotrDogov_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ProcDogovor.xaml", UriKind.Relative));

        }
    }
}
