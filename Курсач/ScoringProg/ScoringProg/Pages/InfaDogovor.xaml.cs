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
    /// Логика взаимодействия для InfaDogovor.xaml
    /// </summary>
    public partial class InfaDogovor : Page
    {
        public InfaDogovor()
        {
            InitializeComponent();
            iduser = ProcDogovor.idusers; // определение id пользоватлея для другой таблицы в БД

        }
        public int iduser;

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ProcDogovor.xaml", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();
            DataTable dt_anketa = podBD.Select("Select * FROM [Anketa] where [id_userW] = '" + iduser + "'");
            DataTable dt_anketaQuest = podBD.Select("Select * FROM [Anketa_Questions] where [id_userW] = '" + iduser + "' ");

            if (dt_anketa.Rows.Count > 0)
            {
                for (int i = 0; i < dt_anketa.Rows.Count; i++)
                { // перебираем данные

                    LB_name.Content = ("Имя: " + dt_anketa.Rows[i][2].ToString());
                    LB_surname.Content = ("Фамилия: " + dt_anketa.Rows[i][3].ToString());
                    LB_patronymic.Content = ("Отчество: " + dt_anketa.Rows[i][4].ToString());
                    LB_BirthDate.Content = ("День рождения: " + dt_anketa.Rows[i][5].ToString());
                    if (dt_anketa.Rows[i][6].ToString() == "1")
                    {
                        LB_Pol.Content = ("Пол: Мужской");
                    }
                    else LB_Pol.Content = ("Пол: Женский");
                    LB_SeriaNomerPassport.Content = ("Серия/Номер паспорта: " + dt_anketa.Rows[i][7].ToString());
                    LB_Phone.Content = ("Телефон: " + dt_anketa.Rows[i][8].ToString());

                }
            }

            if (dt_anketaQuest.Rows.Count > 0)
            {
                for (int i = 0; i < dt_anketaQuest.Rows.Count; i++)
                { // перебираем данные
                    LB_Vp1.Content = ("Семейное положение: " + dt_anketaQuest.Rows[i][3].ToString());
                    LB_Vp2.Content = ("Наличие детей, иждивенцев: " + dt_anketaQuest.Rows[i][4].ToString());
                    LB_Vp3.Content = ("Дополнительный доход: " + dt_anketaQuest.Rows[i][5].ToString());
                    LB_Vp4.Content = ("Трудоустройство: " + dt_anketaQuest.Rows[i][6].ToString());
                    LB_Vp5.Content = ("Трудовой стаж: " + dt_anketaQuest.Rows[i][7].ToString());
                    LB_Vp6.Content = ("Квалификация и должность: " + dt_anketaQuest.Rows[i][8].ToString());
                    LB_Vp7.Content = ("Уровень заработной платы: " + dt_anketaQuest.Rows[i][9].ToString());
                    LB_Vp8.Content = ("Кредитная нагрузка: " + dt_anketaQuest.Rows[i][10].ToString());
                    LB_Vp9.Content = ("Уровень образования: " + dt_anketaQuest.Rows[i][11].ToString());
                    LB_Vp10.Content = ("Наличие в собственности: " + dt_anketaQuest.Rows[i][12].ToString());

                }
            }
        }
    }
}
