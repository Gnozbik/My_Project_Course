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
    /// Логика взаимодействия для ProcDogovor.xaml
    /// </summary>
    public partial class ProcDogovor : Page
    {
        public ProcDogovor()
        {
            InitializeComponent();
        }
        public static int idusers { get; set; }

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Admin.xaml", UriKind.Relative));

        }

        public class MyTable
        {
            //public MyTable(string _sostoynia, int _id, string _name, string _surname, string _patronymic, string _Phone, int _summa, int _kolMec, string _vidCredit)
            //{
            //    this.Sostoinya =  _sostoynia;
            //    this.Id = _id;
            //    this.name = _name;
            //    this.surname = _surname;
            //    this.patronymic = _patronymic;
            //    this.Phone = _Phone;

            //    this.SummaCredit = _summa;
            //    this.KolMec = _kolMec;
            //    this.Vid_credit = _vidCredit;
            //}

            //public string Sostoinya { get; set; }
            //public int Id { get; set; }
            //public string name { get; set; }
            //public string surname { get; set; }
            //public string patronymic { get; set; }
            //public string Phone { get; set; }

            //public int SummaCredit { get; set; }
            //public int KolMec { get; set; }
            //public string Vid_credit { get; set; }


            public MyTable(string sostoynia, int id, string name, string surname, string patronymic, string Phone, int summa, int kolMec, string vidCredit)
            {
                this.Sostoinya = sostoynia;
                this.Id = id;
                this.Имя = name;
                this.Фамилия = surname;
                this.Отчество = patronymic;
                this.Телефон = Phone;

                this.Сумма_кредита = summa;
                this.Количество_месяцев = kolMec;
                this.Вид_кредита = vidCredit;
            }

            public string Sostoinya { get; set; }
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
            string sos = "";
            PodBD podBD = new PodBD();
            DataTable dt_anketa = podBD.Select("Select * FROM [Anketa] where [An_Sostoynie] != '"+ sos +"'");
            DataTable dt_vibCredit = podBD.Select("Select * FROM [Vibor_Credit]");

            List<MyTable> result = new List<MyTable>();
            if (dt_anketa.Rows.Count > 0 && dt_vibCredit.Rows.Count > 0)
            {
                for (int i = 0; i < dt_anketa.Rows.Count; i++)
                { // перебираем данные
                    //result.Add(new MyTable(dt_anketa.Rows[i][9].ToString(), Convert.ToInt32(dt_anketa.Rows[i][1]), dt_anketa.Rows[i][2].ToString(), dt_anketa.Rows[i][3].ToString(), dt_anketa.Rows[i][4].ToString(), dt_anketa.Rows[i][8].ToString(), Convert.ToInt32(dt_vibCredit.Rows[i][3]), Convert.ToInt32(dt_vibCredit.Rows[i][4]), dt_vibCredit.Rows[i][6].ToString()));
                    
                    // Рабочий вариант
                    result.Add(new MyTable(dt_anketa.Rows[i][9].ToString(), Convert.ToInt32(dt_anketa.Rows[i][1]), dt_anketa.Rows[i][2].ToString(), dt_anketa.Rows[i][3].ToString(), dt_anketa.Rows[i][4].ToString(), dt_anketa.Rows[i][8].ToString(), Convert.ToInt32(dt_vibCredit.Rows[i][3]), Convert.ToInt32(dt_vibCredit.Rows[i][4]), dt_vibCredit.Rows[i][6].ToString()));
                        //listBox.Items.Add(dt_anketa.Rows[i][2] + " | " + dt_anketa.Rows[i][3] + " | " + dt_anketa.Rows[i][4] + " | " + dt_anketa.Rows[i][8]);
                    
                }
            }
            dataGrid.ItemsSource = result;


        }

        private void dataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyTable path = dataGrid.SelectedItem as MyTable;
            if ( path != null)
            {
                idusers = path.Id;
                NavigationService.Navigate(new Uri("/Pages/InfaDogovor.xaml", UriKind.Relative));
            }
        }
    }
}
