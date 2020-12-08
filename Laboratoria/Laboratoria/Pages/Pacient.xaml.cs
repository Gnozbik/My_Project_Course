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

namespace Laboratoria.Pages
{
    /// <summary>
    /// Логика взаимодействия для Pacient.xaml
    /// </summary>
    public partial class Pacient : Page
    {
        public Pacient()
        {
            InitializeComponent();
            prava = Avtorizacia.prava;
            idPacient = Avtorizacia.idPacient;

        }
        public int prava;
        public int idPacient;
        public int ucluga;
        public string statusOrder;

        private void Bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Avtorizacia.xaml?", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();

            DataTable dt_pacient = podBD.Select("Select * FROM [Pacient] where [id_pacient] = '"+ idPacient+"'");
            string[,] col = new string[1, 1];
            for (int k = 0; k < dt_pacient.Rows.Count; k++)
            {
                for (int i = 0; i < dt_pacient.Rows.Count; i++)
                { // перебираем данные
                    col[k, i] = (dt_pacient.Rows[k][i + 1].ToString());
                    string  FIO = col[k, i];
                    Lb_infaPacienta.Content = "Пациент: "+FIO;
                }
            }

        }

        private void Bt_zapic_Click(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();

            switch (Cb_typUclug.SelectedIndex)
            {
                case 0:
                    ucluga = 1;
                    break;
                case 1:
                    ucluga = 2;
                    break;
                case 2:
                    ucluga = 3;
                    break;
                case 3:
                    ucluga = 4;
                    break;
                case 4:
                    ucluga = 7;
                    break;
            }

            statusOrder = "Обработка";
            DataTable dt_order = podBD.INSERT("Insert into [Order] (id_uclugLab, Status_order) values ('"+ ucluga+"','"+ statusOrder+"')");

        }
    }
}
