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
    /// Логика взаимодействия для Capcha.xaml
    /// </summary>
    public partial class Capcha : Page
    {
        Random rnd = new Random();

        public Capcha()
        {
            InitializeComponent();
        }

        private void GenerateCapcha()
        {
            string fullAlphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

            capcha_Tb.Text = "";
            for (int i = 0; i < 5; ++i)
                capcha_Tb.Text += fullAlphabet[rnd.Next(fullAlphabet.Length)];
        }



        private void Bt_send_Click(object sender, RoutedEventArgs e)
        {
            if (enter_textBox.Text == capcha_Tb.Text)
                NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml", UriKind.Relative));

            else
            {
                enter_textBox.Clear();
                GenerateCapcha();
            }
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateCapcha();

        }

        private void Bt_new_Click(object sender, RoutedEventArgs e)
        {
            enter_textBox.Clear();
            GenerateCapcha();

        }
    }
}
