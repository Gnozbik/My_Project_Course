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
    /// Логика взаимодействия для Registratia.xaml
    /// </summary>
    public partial class Registratia : Window
    {
        public Registratia()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        public void Reset()
        {
            textBox_Surname.Text = "";
            textBox_Name.Text = "";
            textBox_login.Text = "";
            textBox_Passw.Text = "";
            textBox_Passw_Copy.Text = "";
        }
        public DataTable INSERT(string insertsql) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-74QPDFI\SQLEXPRESS;Initial Catalog=Scoring;Integrated Security=True");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = insertsql;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        private void bt_Zareg_Click(object sender, RoutedEventArgs e)
        {

            string surname = textBox_Surname.Text;
            string name = textBox_Name.Text;
            string login  = textBox_login.Text;
            string password = textBox_Passw.Text;
            int prava = 1;

            if (textBox_Surname.Text.Length > 0) // проверяем Фамилию
            { 
                if (textBox_Name.Text.Length > 0) //проверяем имя
                {
                    if (textBox_login.Text.Length > 0) //проверяем логин
                    {
                        string[] dataLogin = textBox_login.Text.Split('@'); // делим строку на две части
                        if (dataLogin.Length == 2) // проверяем если у нас две части
                        {
                            string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                            if (data2Login.Length == 2)
                            {
                                if (textBox_Passw.Text.Length > 0) //проверяем пароль
                                {
                                    if (textBox_Passw_Copy.Text.Length > 0) //проверяем повтор пароля
                                    {
                                        if (textBox_Passw.Text == textBox_Passw_Copy.Text) // проверка на совпадение паролей
                                        {
                                            DataTable dt_user = INSERT("Insert into User_work (userW_name,userW_surname,userW_login,userW_password,userW_prava) values('" + surname + "','" + name + "','" + login + "','" + password + "','" + prava + "')");
                                            MessageBox.Show("Пользователь зарегистрирован");
                                        } else MessageBox.Show("Пароли не совподают");
                                    }else MessageBox.Show("Укажите повтор пароля");
                                }else MessageBox.Show("Укажите пароль");
                            }else MessageBox.Show("Укажите логин в форме х@x.x");
                        }else MessageBox.Show("Укажите логин в форме х@x.x");                     
                    }else MessageBox.Show("Укажите Логин");
                }else MessageBox.Show("Укажите Имя");
            }else MessageBox.Show("Укажите Фамилию");






        }
    }
}
