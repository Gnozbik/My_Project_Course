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
    /// Логика взаимодействия для InfaZaivky.xaml
    /// </summary>
    public partial class InfaZaivky : Page
    {
        public InfaZaivky()
        {
            InitializeComponent();
            iduser = Zaivky.idusers; // определение id пользоватлея для другой таблицы в БД
        }
        public int iduser;
        public string sostoynie;
        public int idAnketQuest;
        private void bt_back_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Zaivky.xaml", UriKind.Relative));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();
            DataTable dt_anketa = podBD.Select("Select * FROM [Anketa] where [id_userW] = '" + iduser + "'");
            DataTable dt_anketaQuest = podBD.Select("Select * FROM [Anketa_Questions] where [id_userW] = '" + iduser + "' ");

            // получение id Anketa_Questions
            if (dt_anketaQuest.Rows.Count > 0)
            {
                for (int i = 0; i < dt_anketaQuest.Rows.Count; i++)
                { // перебираем данные
                    idAnketQuest = Convert.ToInt32(dt_anketaQuest.Rows[i][0]);
                   // label1.Content = (idAnketQuest);

                }
            }
            DataTable dt_MarkQuest = podBD.Select("Select * FROM [Mark_Questions] where [id_Anketa_Questions] = '" + idAnketQuest + "' ");
            //if (dt_MarkQuest.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt_MarkQuest.Rows.Count; i++)
            //    { // перебираем данные
            //        label1.Content = (dt_MarkQuest.Rows[i][2].ToString());
            //    }
            //}

            if (dt_anketa.Rows.Count > 0)
            {
                for (int i = 0; i < dt_anketa.Rows.Count; i++)
                { // перебираем данные
                   
                        LB_name.Content = ( "Имя: " + dt_anketa.Rows[i][2].ToString());
                        LB_surname.Content = ( "Фамилия: " + dt_anketa.Rows[i][3].ToString());
                        LB_patronymic.Content = ( "Отчество: " + dt_anketa.Rows[i][4].ToString());
                        LB_BirthDate.Content = ( "День рождения: " + dt_anketa.Rows[i][5].ToString());
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
                    LB_Vp1.Content = (dt_MarkQuest.Rows[i][2].ToString() +" Баллов (Мин 38, Макс 65) |  "+ "Семейное положение: " + dt_anketaQuest.Rows[i][3].ToString());
                    LB_Vp2.Content = (dt_MarkQuest.Rows[i][3].ToString() + " Баллов (Мин 40, Макс 65) |  " + "Наличие детей, иждивенцев: " + dt_anketaQuest.Rows[i][4].ToString());
                    LB_Vp3.Content = (dt_MarkQuest.Rows[i][4].ToString() + " Баллов (Мин 38, Макс 65) |  " + "Дополнительный доход: " + dt_anketaQuest.Rows[i][5].ToString());
                    LB_Vp4.Content = (dt_MarkQuest.Rows[i][5].ToString() + " Баллов (Мин 10, Макс 65) |  " + "Трудоустройство: " + dt_anketaQuest.Rows[i][6].ToString());
                    LB_Vp5.Content = (dt_MarkQuest.Rows[i][6].ToString() + " Баллов (Мин 10, Макс 65) |  " + "Трудовой стаж: " + dt_anketaQuest.Rows[i][7].ToString());
                    LB_Vp6.Content = (dt_MarkQuest.Rows[i][7].ToString() + " Баллов (Мин 38, Макс 65) |  " + "Квалификация и должность: " + dt_anketaQuest.Rows[i][8].ToString());
                    LB_Vp7.Content = (dt_MarkQuest.Rows[i][8].ToString() + " Баллов (Мин 20, Макс 65) |  " + "Уровень заработной платы: " + dt_anketaQuest.Rows[i][9].ToString());
                    LB_Vp8.Content = (dt_MarkQuest.Rows[i][9].ToString() + " Баллов (Мин 38, Макс 60) |  " + "Кредитная нагрузка: " + dt_anketaQuest.Rows[i][10].ToString());
                    LB_Vp9.Content = (dt_MarkQuest.Rows[i][10].ToString() + " Баллов (Мин 30, Макс 65) |  " + "Уровень образования: \n" + dt_anketaQuest.Rows[i][11].ToString());
                    LB_Vp10.Content = (dt_MarkQuest.Rows[i][11].ToString() + " Баллов (Мин 40, Макс 65) |  " + "Наличие в собственности: " + dt_anketaQuest.Rows[i][12].ToString());

                    int ItogMark = (Convert.ToInt32(dt_MarkQuest.Rows[i][2])+ Convert.ToInt32(dt_MarkQuest.Rows[i][3]) + Convert.ToInt32(dt_MarkQuest.Rows[i][4]) + Convert.ToInt32(dt_MarkQuest.Rows[i][5]) + Convert.ToInt32(dt_MarkQuest.Rows[i][6]) + Convert.ToInt32(dt_MarkQuest.Rows[i][7]) + Convert.ToInt32(dt_MarkQuest.Rows[i][8]) + Convert.ToInt32(dt_MarkQuest.Rows[i][9]) + Convert.ToInt32(dt_MarkQuest.Rows[i][10]) + Convert.ToInt32(dt_MarkQuest.Rows[i][11]));
                    Lb_ItogMark.Content = ("Минимальный балл для одобрения 445, \nУ заявителя: "+ItogMark.ToString());
                }
                
            }

            
        }

        PodBD podBD = new PodBD();

        private void bt_Otkaz_Click(object sender, RoutedEventArgs e)
        {
            sostoynie = "Отказ";
            // DataTable dt_anketa = podBD.Select("Select * FROM [Anketa] where [id_userW] = '" + iduser + "'");
            DataTable dt_anketa = podBD.UPDATE("Update Anketa  set An_Sostoynie = '" + sostoynie + "' where id_userW = '" + iduser + "'");
            DataTable dt_UserDopuck = podBD.UPDATE("Update User_work set userW_Dopuck = '" + 0 + "' where id_userW = '" + iduser + "'");
            MessageBox.Show("Вы отказали");

        }

        private void bt_Odobren_Click(object sender, RoutedEventArgs e)
        {
            sostoynie = "Одобрен";
            DataTable dt_anketa = podBD.UPDATE("Update Anketa  set An_Sostoynie = '" + sostoynie + "' where id_userW = '" + iduser + "'");
            DataTable dt_UserDopuck = podBD.UPDATE("Update User_work set userW_Dopuck = '" + 0 + "' where id_userW = '" + iduser + "'");
            MessageBox.Show("Вы одобрели");

        }
    }
}
