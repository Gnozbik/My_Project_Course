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
    /// Логика взаимодействия для GlavEcran.xaml
    /// </summary>
    public partial class GlavEcran : Page
    {
        public GlavEcran()
        {
            InitializeComponent();

        }

        //public int idusers;
        public static int idusers { get; set; }
        public static int doctup { get; set; }
       
        private void ButtonLog_in_Click(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();


            if (textBox_login.Text.Length > 0)
            {
                if (textBox_password.Text.Length > 0)
                {
                    //DataTable dt_user = Select("Select * FROM [User_work] where [userW_login] = '" + textBox_login.Text + "' and [userW_password] = '" + textBox_password.Text + "'");
                    DataTable dt_user = podBD.Select("Select * FROM [User_work] where [userW_login] = '" + textBox_login.Text + "' and [userW_password] = '" + textBox_password.Text + "'");


                    if (dt_user.Rows.Count > 0)
                    {
                        int[,] col = new int[1, 1];
                        for (int k = 0; k < dt_user.Rows.Count; k++)
                        {
                            for (int i = 0; i < dt_user.Rows.Count; i++)
                            { // перебираем данные
                              //MessageBox.Show(dt_user.Rows[i][0] + "|" + dt_user.Rows[i][5]); // выводим данные
                                col[k, i] = int.Parse(dt_user.Rows[k][i + 5].ToString());
                                int prava = col[k, i];
                                col[k, i] = int.Parse(dt_user.Rows[k][i].ToString());
                                idusers = col[k, i]; // получение id пользователя
                                //col[k, i] = int.Parse(dt_user.Rows[k][i+6].ToString());
                                //doctup = col[k, i];
                                //MessageBox.Show(col[k,i].ToString());

                                if (prava == 1)
                                {
                                    // new Users().Show();
                                    //this.Close();
                                    NavigationService.Navigate(new Uri("/Pages/Users.xaml?", UriKind.Relative));
                                    //MessageBox.Show("Пользователь авторизовался " + idusers);
                                }
                                else
                                {
                                    // new Admins().Show();
                                    // this.Close();
                                    NavigationService.Navigate(new Uri("/Pages/Admin.xaml", UriKind.Relative));
                                    //MessageBox.Show("Hello Admin " + idusers);
                                }
                            }
                        }




                        //new Users().Show();
                        //this.Close();
                        //MessageBox.Show("Пользователь авторизовался");
                    }
                    else MessageBox.Show("Пользователь не найден");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");




        }
        private void ButtonRegist_in_Click(object sender, RoutedEventArgs e)
        {
         
            NavigationService.Navigate(new Uri("/Pages/Registra.xaml", UriKind.Relative));
        }

        private void label3_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
