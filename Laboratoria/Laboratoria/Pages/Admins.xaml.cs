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

namespace Laboratoria.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admins.xaml
    /// </summary>
    public partial class Admins : Page
    {
        public Admins()
        {
            InitializeComponent();
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml?", UriKind.Relative));

        }
    }
}
