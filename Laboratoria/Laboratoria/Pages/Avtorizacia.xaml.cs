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
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Avtorizacia()
        {
            InitializeComponent();
        }
        public static int prava { get; set; }
        public static int idPacient { get; set; }

        public int kol = 0;
        private void Bt_vhod_Click(object sender, RoutedEventArgs e)
        {
            PodBD podBD = new PodBD();

                if (Tb_login.Text.Length > 0 && pwdPasswordBox.Password.Length > 0)
                {
                    
                        DataTable dt_user = podBD.Select("Select * FROM [Users] where [Login] = '" + Tb_login.Text + "' and [Password] = '" + pwdPasswordBox.Password + "'");


                    if (dt_user.Rows.Count > 0)
                    {
                        int[,] col = new int[1, 1];
                        for (int k = 0; k < dt_user.Rows.Count; k++)
                        {
                            for (int i = 0; i < dt_user.Rows.Count; i++)
                            { // перебираем данные
                                col[k, i] = int.Parse(dt_user.Rows[k][i + 7].ToString());
                                prava = col[k, i];
                                //col[k, i] = int.Parse(dt_user.Rows[k][i + 3].ToString());
                                //idPacient = col[k, i];
                               // MessageBox.Show(prava.ToString());

                                switch (prava)
                                {
                                    case 1:
                                        NavigationService.Navigate(new Uri("/Pages/Pacient.xaml?", UriKind.Relative));
                                    for (i = 0; i < dt_user.Rows.Count; i++)
                                    {
                                        col[k, i] = int.Parse(dt_user.Rows[k][i + 3].ToString());
                                        idPacient = col[k, i];

                                    }
                                    break;
                                    case 2:
                                        NavigationService.Navigate(new Uri("/Pages/Admins.xaml?", UriKind.Relative));
                                        break;
                                    case 3:
                                        NavigationService.Navigate(new Uri("/Pages/Laborant.xaml?", UriKind.Relative));
                                        break;
                                    case 4:
                                        NavigationService.Navigate(new Uri("/Pages/Bookers.xaml?", UriKind.Relative));
                                        break;

                                }
                            }
                        }
                        
                    }
                    else
                    {
                        switch (kol)
                        {
                            case 0:
                            MessageBox.Show("Пользователь не найден");
                            break;

                            case 1:
                            MessageBox.Show("Пользователь не найден");
                            break;

                            case 2:
                            NavigationService.Navigate(new Uri("/Pages/Capcha.xaml", UriKind.Relative));
                            break;

                            case 3:

                                break;
                        }
                    kol++;
                        //MessageBox.Show("Пользователь не найден");
                        
                    }
                    
                }
                else MessageBox.Show("Введите корректно логин и пароль");
         




        }



        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = pwdPasswordBox.Password; // скопируем в TextBox из PasswordBox
                pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
                pwdPasswordBox.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
                pwdTextBox.Visibility = Visibility.Hidden; // TextBox - скрыть
                pwdPasswordBox.Visibility = Visibility.Visible; // PasswordBox - отобразить

            }

        }
    }
}
