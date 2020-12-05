using ScoringProg.Pages;
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

namespace ScoringProg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            frame.Navigate(new GlavEcran()); // открытие страницы

            //new LinkVeb().Show();
            //this.Close();

            //DataTable dt_user = Select("SELECT * FROM [dbo].[User_work]"); // получаем данные из таблицы

            //for (int k = 0; k < dt_user.Rows.Count;)
            //{
            //    for (int i = 0; i < dt_user.Rows.Count;)
            //    { // перебираем данные
            //        MessageBox.Show(dt_user.Rows[k][i] + "|" + dt_user.Rows[k][i + 1] + "|" + dt_user.Rows[k][i + 2] + "|" + dt_user.Rows[k][i + 3] + "|" + dt_user.Rows[k][i + 4] + "|" + dt_user.Rows[k][i + 5]); // выводим данные
            //        k++;
            //    }
            //}
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-74QPDFI\SQLEXPRESS;Initial Catalog=Scoring;Integrated Security=True");


        //public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        //{
        //    DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
        //                                                                    // подключаемся к базе данных
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-74QPDFI\SQLEXPRESS;Initial Catalog=Scoring;Integrated Security=True");
        //    sqlConnection.Open();                                           // открываем базу данных
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
        //    sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
        //    sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
        //    return dataTable;
        //}

        //private void ButtonLog_in_Click(object sender, RoutedEventArgs e)
        //{


        //    if (textBox_login.Text.Length > 0)
        //    {
        //        if (textBox_password.Text.Length > 0)
        //        {
        //            DataTable dt_user = Select("Select * FROM [User_work] where [userW_login] = '" + textBox_login.Text + "' and [userW_password] = '" + textBox_password.Text +"'");
        //           // DataTable dt_prava = Select("Select * FROM [User_work] where [userW_prava] = '"+ prava +"'");

        //            if (dt_user.Rows.Count >0)
        //            {
        //                int [,]col = new int[1,1];
        //                for (int k = 0; k < dt_user.Rows.Count;k++)
        //                {
        //                    for (int i = 0; i < dt_user.Rows.Count; i++)
        //                    { // перебираем данные
        //                      //MessageBox.Show(dt_user.Rows[i][0] + "|" + dt_user.Rows[i][5]); // выводим данные
        //                        col[k, i] = int.Parse(dt_user.Rows[k][i+5].ToString());
        //                        int prava = col[k, i];
        //                        //MessageBox.Show(col[k,i].ToString());

        //                        if (prava == 1)
        //                        {
        //                            new Users().Show();
        //                            this.Close();
        //                            MessageBox.Show("Пользователь авторизовался");

        //                        }
        //                        else
        //                        {
        //                            new Admins().Show();
        //                            this.Close();
        //                            MessageBox.Show("Hello Admin");
        //                        }
        //                    }
        //                }




        //                //new Users().Show();
        //                //this.Close();
        //                //MessageBox.Show("Пользователь авторизовался");
        //            }
        //            else MessageBox.Show("Пользователь не найден");
        //        }else MessageBox.Show("Введите пароль");
        //    }else MessageBox.Show("Введите логин");




        //}

        //private void ButtonRegist_in_Click(object sender, RoutedEventArgs e)
        //{
        //    new Registratia().Show();
        //    this.Close();


        //}
    }
}
