using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();

            iduser = GlavEcran.idusers; // определение id пользоватлея для другой таблицы в БД

        }
        public int doctup;
        public int iduser;

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GlavEcran.xaml", UriKind.Relative));
        }

        private void bt_ProityAnketu_Click(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();
            DataTable dt_dopuck = podBD.Select("Select * FROM [User_work] where [id_userW] = '"+ iduser + "'");
            
                int[,] col = new int[1, 1];
                for (int k = 0; k < dt_dopuck.Rows.Count; k++)
                {
                    for (int i = 0; i < dt_dopuck.Rows.Count; i++)
                    { // перебираем данные
                        //MessageBox.Show(dt_dopuck.Rows[i][0] + "|" + dt_dopuck.Rows[i][6]); // выводим данные
                        col[k, i] = int.Parse(dt_dopuck.Rows[k][i+6].ToString());
                        doctup = col[k, i];
                        //MessageBox.Show(col[k,i].ToString());
                    }
                }            

            if (doctup == 0)
            {
                NavigationService.Navigate(new Uri("/Pages/Anketirovanie.xaml", UriKind.Relative));
            }
            else MessageBox.Show("Ждите ответа предыдущей анкеты");
        }

        private void bt_HistoyPlateg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/HistoryPlatagei.xaml", UriKind.Relative));

        }
    }
}
