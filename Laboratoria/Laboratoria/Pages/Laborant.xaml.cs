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
using System.Windows.Threading;

namespace Laboratoria.Pages
{
    /// <summary>
    /// Логика взаимодействия для Laborant.xaml
    /// </summary>
    public partial class Laborant : Page
    {
        public Laborant()
        {
            InitializeComponent();
        }

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml?", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(60);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private int minut = 0;
        private int Chac = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            minut++;
            if (minut == 60)
            {
                Chac++;
                minut = 0;
            }
            Lb_Timer_vivod.Content = Chac.ToString() + ":" + minut.ToString();
            if (Chac == 2 && minut == 15)
            {
                MessageBox.Show("До окончания сеанса осталось 15 минут");
            }
            if (Chac == 2 && minut == 30)
            {
                NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml?", UriKind.Relative));
            }

            PodBD podBD = new PodBD();
            DataTable dt_order = podBD.Select("Select * FROM [Order]");
            DataTable dt_pacient = podBD.Select("Select * FROM [Pacient]");


            //List<MyTable> result = new List<MyTable>();
            //if (dt_anketa.Rows.Count > 0 && dt_vibCredit.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt_anketa.Rows.Count; i++)
            //    { // перебираем данные
            //        if (dt_anketa.Rows[i][9].ToString() == "")
            //        {
            //            result.Add(new MyTable(Convert.ToInt32(dt_anketa.Rows[i][1]), dt_anketa.Rows[i][2].ToString(), dt_anketa.Rows[i][3].ToString(), dt_anketa.Rows[i][4].ToString(), dt_anketa.Rows[i][8].ToString(), Convert.ToInt32(dt_vibCredit.Rows[i][3]), Convert.ToInt32(dt_vibCredit.Rows[i][4]), dt_vibCredit.Rows[i][6].ToString()));
            //        }
            //    }
            //}
            //dataGrid.ItemsSource = result;


        }

        class MyTable
        {
                    public MyTable(int order, string FIO)
                    {
                        this.Order = order;
                        this.ФИО = FIO;
                    }

                    public int Order { get; set; }
                    public string ФИО { get; set; }


        }

    }

     
}
