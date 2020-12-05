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
    /// Логика взаимодействия для Zaivky.xaml
    /// </summary>
    public partial class Zaivky : Page
    {
        public Zaivky()
        {
            InitializeComponent();
        }
        public static int idusers { get; set; }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Admin.xaml", UriKind.Relative));

        }

        class MyTable
        {
            public MyTable(int id,string name, string surname, string patronymic, string Phone, int summa, int kolMec, string vidCredit)
            {
                this.Id = id;
                this.Имя = name;
                this.Фамилия = surname;
                this.Отчество = patronymic;
                this.Телефон = Phone;

                this.Сумма_кредита = summa;
                this.Количество_месяцев = kolMec;
                this.Вид_кредита = vidCredit;
            }

            public int Id { get; set; }
            public string Имя { get; set; }
            public string Фамилия { get; set; }
            public string Отчество { get; set; }
            public string Телефон { get; set; }

            public int Сумма_кредита { get; set; }
            public int Количество_месяцев { get; set; }
            public string Вид_кредита { get; set; }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();
            DataTable dt_anketa = podBD.Select("Select * FROM [Anketa]");
            DataTable dt_vibCredit = podBD.Select("Select * FROM [Vibor_Credit]");

            List<MyTable> result = new List<MyTable>();
            if (dt_anketa.Rows.Count > 0 && dt_vibCredit.Rows.Count > 0)
            {
                    for (int i = 0; i < dt_anketa.Rows.Count; i++)
                    { // перебираем данные
                       if (dt_anketa.Rows[i][9].ToString() == "")
                       {
                        result.Add(new MyTable(Convert.ToInt32(dt_anketa.Rows[i][1]), dt_anketa.Rows[i][2].ToString(), dt_anketa.Rows[i][3].ToString(), dt_anketa.Rows[i][4].ToString(), dt_anketa.Rows[i][8].ToString(), Convert.ToInt32(dt_vibCredit.Rows[i][3]), Convert.ToInt32(dt_vibCredit.Rows[i][4]), dt_vibCredit.Rows[i][6].ToString()));
                       }
                    }
            }
            dataGrid.ItemsSource = result;




        }

        private void dataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyTable path = dataGrid.SelectedItem as MyTable;
            if (path != null)
            {
                idusers = path.Id;
                NavigationService.Navigate(new Uri("/Pages/InfaZaivky.xaml", UriKind.Relative));
            }

        }
    }
}
