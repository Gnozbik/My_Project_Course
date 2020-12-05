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
    /// Логика взаимодействия для VibKredit.xaml
    /// </summary>
    public partial class VibKredit : Page
    {
        public VibKredit()
        {
            InitializeComponent();
            iduser = GlavEcran.idusers; // определение id пользоватлея для другой таблицы в БД
            doctup = GlavEcran.doctup; // определение доступ пользоватлея для другой таблицы в БД
            idanketa = Anketirovanie.idanketa;
        }
        public int doctup;
        public int iduser;
        public int idmonth = 0;
        public int TipKredit=0;
        public bool isPress = false;
        public string vidCredit;
        public int summ = 0, Month = 0;
        //public double SummProc;  // Сумма которая идет на погашение процентов
        //public double SummOst; //Сумма остаток по кредиту
        //public double SummPogah; //Сумма которая идет на погашение основной сумму
        //public double SummDolg; // Долг на конец месяца

        //public double YearProcent = 18.9;
        public double YearProcent = 22;
        public int idanketa;
        private void bt_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Anketirovanie.xaml", UriKind.Relative));

        }

        private void bt_Racchit_Click(object sender, RoutedEventArgs e)
        {

            Lb_GodPocent.Content = ("Условие кредита \n" + "Годовой процент: " + YearProcent.ToString());
            listViewPayments.Items.Clear();
            isPress = true;

            if (RB_Annuitet.IsChecked == true)
            {

                TipKredit = 1;
                idmonth = 0;
                // EveryMonth - это ежемесячный аннуитетный платёж
                // koefAn - это коэффициент аннуитета
                // summ - это сумма кредита
                // MonthPer - это месячная процентная ставка по кредиту
                // Month - это количество периодов, в течение которых выплачивается кредит  
                // YearProcent - это годовой процент 
                double EveryMonth = 0, koefAn = 0, MonthPer = 0;
                double SummProc;  // Сумма которая идет на погашение процентов
                double SummOst; //Сумма остаток по кредиту
                double SummPogah; //Сумма которая идет на погашение основной сумму
                double SummDolg; // Долг на конец месяца


                 summ = Convert.ToInt32(TB_Summa.Text);
                Month = Convert.ToInt32(TB_kolmec.Text);
                MonthPer = YearProcent / 100 / 12;
                //koefAn = (MonthPer * Math.Pow((1 + MonthPer), Month)) / (Math.Pow((1 + MonthPer), Month) - 1);
                koefAn = (MonthPer + (MonthPer / (Math.Pow((1 + MonthPer), Month) - 1)));
                double all = 0, allproc = 0, allTel = 0;
                SummOst = summ;
                for (int i = 0; i < Month; i++)
                {
                    EveryMonth = summ * koefAn;

                    SummProc = SummOst * MonthPer;
                    SummDolg = SummOst - EveryMonth;
                    SummOst -= EveryMonth;
                    SummPogah = EveryMonth - SummProc;

                    idmonth += 1;
                    //ListViewItem lva = new ListViewItem(("Месяц  " + idmonth + " =" + EveryMonth).ToString());
                    listViewPayments.Items.Add(("Месяц " + idmonth + " =" + Convert.ToInt32(EveryMonth)).ToString() + " Процент " + Convert.ToInt32(SummProc).ToString() + " Погашение тела " + Convert.ToInt32(SummPogah).ToString() + " Остаток " + Convert.ToInt32(SummDolg).ToString());
                    all += EveryMonth;
                    allproc += SummProc;
                    allTel += SummPogah;
                }
                listViewPayments.Items.Add("ИТОГО: " + Convert.ToInt32(all).ToString() + " Процент " + Convert.ToInt32(allproc).ToString() + " Тело " + Convert.ToInt32(allTel).ToString());
            }
            else if (RB_Differen.IsChecked == true)
            {
                TipKredit = 0;
                idmonth = 0;

                // EveryMonth - это ежемесячный диффренцированного платёже
                // SummPogah - это сумма которая идет на погашение тела
                // SummProc - это сумма которая идет на погашение процентов
                // SummOst - это остаток задолжности по кредиту
                double EveryMonth = 0, SummPogah = 0, SummProc = 0, SummOst = 0, all = 0, allproc = 0, allTel = 0, proc = 0, telo = 0, MonthPer=0 ;
                MonthPer = YearProcent / 100 / 12;

                summ = Convert.ToInt32(TB_Summa.Text);
                Month = Convert.ToInt32(TB_kolmec.Text);
                SummPogah = summ / Month; //4166
                for (int i = 0; i < Month; i++)
                {
                    SummOst = summ - SummPogah; // 45834
                    SummProc = (SummOst * YearProcent / 100) / 12; //840

                    EveryMonth = SummPogah + SummProc;

                    proc = SummOst * MonthPer;
                    telo = EveryMonth - proc;
                    idmonth += 1;

                    listViewPayments.Items.Add(("Месяц " + idmonth+ " =" + Convert.ToInt32(EveryMonth).ToString() + " Процент " + Convert.ToInt32(proc).ToString() + " Погашение тела " + Convert.ToInt32(telo).ToString()));
                    all += EveryMonth;
                    allproc += proc;
                    allTel += telo;

                }
                listViewPayments.Items.Add("ИТОГО: " + Convert.ToInt32(all).ToString() + " Процент " + Convert.ToInt32(allproc).ToString() + " Тело " + Convert.ToInt32(allTel).ToString());

            }
            else MessageBox.Show("Выберите тип платежей");


            //vid = LB_vidKred.SelectedItem.ToString();

            if (LB_vidKred.SelectedItem != null)
            {
                vidCredit = LB_vidKred.SelectedItem.ToString();

            }
            else MessageBox.Show("Выберите вид кредита");

        }

        private void bt_Otpr_Click(object sender, RoutedEventArgs e)
        {
            
            if (isPress == true)
            {

                PodBD podBD = new PodBD();
                doctup = 1;
                ////////////////////////////////////////////////////////////////////
                //Сбор id анкеты 
                //DataTable dt_idanket = podBD.Select("Select * FROM [Anketa]");

                //if (dt_idanket.Rows.Count > 0)
                //{
                //    int[,] col = new int[1, 1];
                //    for (int k = 0; k < dt_idanket.Rows.Count; k++)
                //    {
                //        for (int i = 0; i < dt_idanket.Rows.Count; i++)
                //        { // перебираем данные
                //            col[k, i] = int.Parse(dt_idanket.Rows[k][i].ToString());
                //            idanketa = col[k, i]; 
                //            // получение id анкеты         
                //                                  //MessageBox.Show(dt_idanket.Rows[i][0] +""); // выводим данные
                //                                  //MessageBox.Show(idanketa.ToString());
                //        }
                //    }
                //}
                /////////////////////////////////////////////////////////////////////               

                string GodProcent = Convert.ToString(YearProcent);
                //отправка данных в бд
                DataTable dt_Vibkred = podBD.INSERT("Insert into Vibor_Credit (id_userW,id_Anketa,VC_Summa,VC_KolMec,VC_TipCredit,VC_VidCredit,VC_GodProcent) values('"+ iduser + "','" + idanketa + "','" + summ + "','" + Month + "','" + TipKredit + "','" + vidCredit + "','" + GodProcent + "')");
                DataTable dt_doctup = podBD.UPDATE("Update User_work  set userW_Dopuck = '" + doctup+"' where id_userW = '" + iduser + "'");

                NavigationService.Navigate(new Uri("/Pages/Users.xaml", UriKind.Relative));
                MessageBox.Show("Анкета отправлена, ждите ответа");
            }
            else MessageBox.Show("Сначала рассчитайте платеж");
        }
    }
}
