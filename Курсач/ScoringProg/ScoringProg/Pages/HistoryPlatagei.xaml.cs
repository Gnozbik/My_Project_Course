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
    /// Логика взаимодействия для HistoryPlatagei.xaml
    /// </summary>
    public partial class HistoryPlatagei : Page
    {
        public HistoryPlatagei()
        {
            InitializeComponent();
        }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Users.xaml", UriKind.Relative));

        }
    }
}
