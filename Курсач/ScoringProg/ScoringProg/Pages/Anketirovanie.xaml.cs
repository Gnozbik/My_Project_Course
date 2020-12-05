using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
//using Xceed.Wpf.Toolkit;
namespace ScoringProg.Pages
{
    /// <summary>
    /// Логика взаимодействия для Anketirovanie.xaml
    /// </summary>
    public partial class Anketirovanie : Page
    {
        public Anketirovanie()
        {
            InitializeComponent();
            iduser = GlavEcran.idusers; // определение id пользоватлея для другой таблицы в БД
           

        }
        public int iduser;
        public static int idanketa { get; set; }
        public int idAnketQuest;
        public int Mark1;
        public int Mark2;
        public int Mark3;
        public int Mark4;
        public int Mark5;
        public int Mark6;
        public int Mark7;
        public int Mark8;
        public int Mark9;
        public int Mark10;

        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Users.xaml", UriKind.Relative));
            //MessageBox.Show(Mark1.ToString() + " " + Mark2.ToString() + " " + Mark3.ToString() + " " + Mark4.ToString() + " " + Mark5.ToString() + " " + Mark6.ToString() + " " + Mark7.ToString() + " " + Mark8.ToString() + " " + Mark9.ToString() + " " + Mark10.ToString());           
        }


        public void ChetMark()
        {
            Mark1 = 0;
            Mark2 = 0;
            Mark3 = 0;
            Mark4 = 0;
            Mark5 = 0;
            Mark6 = 0;
            Mark7 = 0;
            Mark8 = 0;
            Mark9 = 0;
            Mark10 = 0;

            //код реализующий подсчет баллов в ComboBox
            switch (CB_v1.SelectedIndex)
            {
                case 0:
                    Mark1 += 50;
                    break;
                case 1:
                    Mark1 += 65;
                    break;
                case 2:
                    Mark1 += 38;
                    break;

            }

            switch (CB_v2.SelectedIndex)
            {
                case 0:
                    Mark2 += 65;
                    break;
                case 1:
                    Mark2 += 60;
                    break;
                case 2:
                    Mark2 += 55;
                    break;
                case 3:
                    Mark2 += 40;
                    break;
            }

            switch (CB_v3.SelectedIndex)
            {
                case 0:
                    Mark3 += 38;
                    break;
                case 1:
                    Mark3 += 58;
                    break;
                case 2:
                    Mark3 += 50;
                    break;
                case 3:
                    Mark3 += 65;
                    break;
            }

            switch (CB_v4.SelectedIndex)
            {
                case 0:
                    Mark4 += 65;
                    break;
                case 1:
                    Mark4 += 60;
                    break;
                case 2:
                    Mark4 += 30;
                    break;
                case 3:
                    Mark4 += 10;
                    break;
            }

            switch (CB_v5.SelectedIndex)
            {
                case 0:
                    Mark5 += 38;
                    break;
                case 1:
                    Mark5 += 50;
                    break;
                case 2:
                    Mark5 += 60;
                    break;
                case 3:
                    Mark5 += 65;
                    break;
                case 4:
                    Mark5 += 10;
                    break;
            }

            switch (CB_v6.SelectedIndex)
            {
                case 0:
                    Mark6 += 65;
                    break;
                case 1:
                    Mark6 += 60;
                    break;
                case 2:
                    Mark6 += 40;
                    break;
                case 3:
                    Mark6 += 60;
                    break;
                case 4:
                    Mark6 += 38;
                    break;
            }

            switch (CB_v7.SelectedIndex)
            {
                case 0:
                    Mark7 += 20;
                    break;
                case 1:
                    Mark7 += 38;
                    break;
                case 2:
                    Mark7 += 50;
                    break;
                case 3:
                    Mark7 += 60;
                    break;
                case 4:
                    Mark7 += 65;
                    break;
            }

            switch (CB_v8.SelectedIndex)
            {
                case 0:
                    Mark8 += 38;
                    break;
                case 1:
                    Mark8 += 60;
                    break;
                case 2:
                    Mark8 += 40;
                    break;

            }

            switch (CB_v9.SelectedIndex)
            {
                case 0:
                    Mark9 += 65;
                    break;
                case 1:
                    Mark9 += 50;
                    break;
                case 2:
                    Mark9 += 30;
                    break;

            }

            switch (CB_v10.SelectedIndex)
            {
                case 0:
                    Mark10 += 65;
                    break;
                case 1:
                    Mark10 += 60;
                    break;
                case 2:
                    Mark10 += 40;
                    break;
                case 3:
                    Mark10 += 50;
                    break;
            }

        }


        private void bt_go_Click(object sender, RoutedEventArgs e)
        {


            PodBD podBD = new PodBD();
            int Pol = 0;
            if (RB_M.IsChecked == true)
            {
                Pol = 1;
                //MessageBox.Show("1");
            }
            else if (RB_G.IsChecked == true)
            {
                Pol = 0;
                //MessageBox.Show("0");

            }
            else MessageBox.Show("Выберите пол");


            string surname = TB_surname.Text;
            string name = TB_name.Text;
            string patronymic = TB_patronymic.Text;
            string BirthDay = TB_BirthDay.Text;
            string SerNomPass = TB_serialnomerpassport.Text;
            string phone = TB_phone.Text;




            if (TB_surname.Text != "")
            {
                if (TB_name.Text != "")
                {
                    if (TB_patronymic.Text != "")
                    {
                        if (TB_BirthDay.Text != "__.__.____")
                        {

                            if (TB_serialnomerpassport.Text != "____-______")
                            {
                                if (TB_phone.Text != "+7(___)___-__-__")
                                {
                                    DataTable dt_anket = podBD.INSERT("Insert into Anketa (id_userW,An_Name,An_Surname,An_Patronymic,An_Birthday,An_Pol,An_SerialNomerPassport,An_Phone) values('" + iduser + "','" + name + "','" + surname + "','" + patronymic + "','" + BirthDay + "','" + Pol + "','" + SerNomPass + "','" + phone + "')");
                                    //MessageBox.Show("Данные отправленны");
                                }
                                else MessageBox.Show("Введите номер телефона");
                            }
                            else MessageBox.Show("Введите номер/серию паспорта");
                        }
                        else MessageBox.Show("Введите Дату рождения");
                    }
                    else MessageBox.Show("Введите Отчество");
                }
                else MessageBox.Show("Введите Имя");
            }
            else MessageBox.Show("Введите Фамилию");

            //DataTable dt_anket = podBD.INSERT("Insert into Anketa (id_userW,An_Name,An_Surname,An_Patronymic,An_Birthday,An_Pol,An_SerialNomerPassport,An_Phone) values('" + iduser + "','" + surname + "','" + name + "','" + patronymic + "','" + BirthDay + "','" + Pol + "','" + SerNomPass + "','" + phone + "')");

            //первый пробный раз
            //DataTable dt_user = INSERT("Insert into Anketa (id_userW,An_Name,An_Surname,An_Patronymic,An_SerialNomerPassport,An_Phone) values('" + iduser + "','" + surname + "','" + name + "','" + patronymic + "','" + SerNomPass + "','" + phone + "')");

            ////////////////////////////////////////////////////////////////////
            //Сбор id анкеты 
            DataTable dt_idanket = podBD.Select("Select * FROM [Anketa] where [id_userW] = '"+ iduser +"'");

            if (dt_idanket.Rows.Count > 0)
            {
                int[,] col = new int[1, 1];
                //for (int k = 0; k < dt_idanket.Rows.Count; k++)
                //{
                    for (int i = 0; i < dt_idanket.Rows.Count; i++)
                    { // перебираем данные
                        //col[k, i] = int.Parse(dt_idanket.Rows[k][i].ToString());
                        idanketa = Convert.ToInt32(dt_idanket.Rows[i][0].ToString());
                        //idanketa = col[k, i]; // получение id анкеты         
                        //MessageBox.Show(dt_idanket.Rows[i][0] +""); // выводим данные
                        //MessageBox.Show(idanketa.ToString());
                    }
                //}
            }
            /////////////////////////////////////////////////////////////////////
            string vp1 = CB_v1.Text.ToString();
            string vp2 = CB_v2.Text.ToString();
            string vp3 = CB_v3.Text.ToString();
            string vp4 = CB_v4.Text.ToString();
            string vp5 = CB_v5.Text.ToString();
            string vp6 = CB_v6.Text.ToString();
            string vp7 = CB_v7.Text.ToString();
            string vp8 = CB_v8.Text.ToString();
            string vp9 = CB_v9.Text.ToString();
            string vp10 = CB_v10.Text.ToString();


            //код реализующий подсчет баллов в ComboBox
            ChetMark();


            if (vp1.Length > 0)
            {
                if (vp2.Length > 0)
                {
                    if (vp3.Length > 0)
                    {
                        if (vp4.Length > 0)
                        {
                            if (vp5.Length > 0)
                            {
                                if (vp6.Length > 0)
                                {
                                    if (vp7.Length > 0)
                                    {
                                        if (vp8.Length > 0)
                                        {
                                            if (vp9.Length > 0)
                                            {
                                                if (vp10.Length > 0)
                                                {
                                                    // записываем в бд
                                                    DataTable dt_ques = podBD.INSERT("Insert into Anketa_Questions (id_Anketa,id_userW,AnQuest_vp1,AnQuest_vp2,AnQuest_vp3,AnQuest_vp4,AnQuest_vp5,AnQuest_vp6,AnQuest_vp7,AnQuest_vp8,AnQuest_vp9,AnQuest_vp10) values('" + idanketa + "','" + iduser + "','" + vp1 + "','" + vp2 + "','" + vp3 + "','" + vp4 + "','" + vp5 + "','" + vp6 + "','" + vp7 + "','" + vp8 + "','" + vp9 + "','" + vp10 + "')");

                                                    // Читаем из бд, чтобы получить id Anketa_Questions
                                                    DataTable dt_IdAnketaQuest = podBD.Select("Select * FROM [Anketa_Questions] where [id_Anketa] = '" + idanketa + "'");

                                                    if (dt_IdAnketaQuest.Rows.Count > 0)
                                                    {
                                                        int[,] col = new int[1, 1];
                                                        for (int i = 0; i < dt_IdAnketaQuest.Rows.Count; i++)
                                                        { // перебираем данные
                                                            idAnketQuest = Convert.ToInt32(dt_IdAnketaQuest.Rows[i][0].ToString());
                                                        }
                                                    }
                                                    //запись в БД оценок за ответы
                                                    DataTable dt_Markques = podBD.INSERT("Insert into Mark_Questions (id_Anketa_Questions,MarkQ_vp1,MarkQ_vp2,MarkQ_vp3,MarkQ_vp4,MarkQ_vp5,MarkQ_vp6,MarkQ_vp7,MarkQ_vp8,MarkQ_vp9,MarkQ_vp10) values('" + idAnketQuest + "','" + Mark1 + "','" + Mark2 + "','" + Mark3 + "','" + Mark4 + "','" + Mark5 + "','" + Mark6 + "','" + Mark7 + "','" + Mark8 + "','" + Mark9 + "','" + Mark10 + "')");

                                                    NavigationService.Navigate(new Uri("/Pages/VibKredit.xaml", UriKind.Relative));
                                                    //MessageBox.Show("Данные заполнены");
                                                }
                                                else MessageBox.Show("Заполните графу (наличие в собственности)");
                                            }
                                            else MessageBox.Show("Заполните графу (уровень образования)");
                                        }
                                        else MessageBox.Show("Заполните графу (Кредитная нагрузка)");
                                    }
                                    else MessageBox.Show("Заполните графу (уровень заработной платы)");
                                }
                                else MessageBox.Show("Заполните графу (квалификация и должность)");
                            }
                            else MessageBox.Show("Заполните графу (трудовой стаж)");
                        }
                        else MessageBox.Show("Заполните графу (трудоустройство)");
                    }
                    else MessageBox.Show("Заполните графу (дополнительный доход)");
                }
                else MessageBox.Show("Заполните графу (наличие детей)");
            }
            else MessageBox.Show("Заполните графу (семейное положение)");


            //DataTable dt_ques = podBD.INSERT("Insert into Anketa_Questions (id_Anketa,id_userW,AnQuest_vp1,AnQuest_vp2,AnQuest_vp3,AnQuest_vp4,AnQuest_vp5,AnQuest_vp6,AnQuest_vp7,AnQuest_vp8,AnQuest_vp9,AnQuest_vp10) values('" + idanketa + "','" + iduser + "','" + vp1 + "','" + vp2 + "','" + vp3 + "','" + vp4 + "','" + vp5 + "','" + vp6 + "','" + vp7 + "','" + vp8 + "','" + vp9 + "','" + vp10 + "')");

            //первый пробный раз
            //DataTable dt_ques = INSERT("Insert into Anketa_Questions (id_Anketa,id_userW,AnQuest_vp1,AnQuest_vp2,AnQuest_vp3,AnQuest_vp4,AnQuest_vp5,AnQuest_vp6,AnQuest_vp7,AnQuest_vp8,AnQuest_vp9,AnQuest_vp10) values('" + iduser + "','" + vp1 + "','" + vp2 + "','" + vp3 + "','" + vp4 + "','" + vp5 + "','" + vp6 + "','" + vp7 + "','" + vp8 + "','" + vp9 + "','" + vp10 + "')");




        }
    }
}
