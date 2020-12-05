using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using HtmlAgilityPack;
//using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Newtonsoft.Json;

namespace ScoringProg
{
    /// <summary>
    /// Логика взаимодействия для LinkVeb.xaml
    /// </summary>
    public partial class LinkVeb : Window
    {
        public LinkVeb()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            //new ProvZai().Show();
            //this.Close();
        }

        private void bt_otp_Click(object sender, RoutedEventArgs e)
        {
            //textBoxInf.Text = "";
            // HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            //////$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //Получение данных 1 вариант, работает криво 
            //string url = "https://kronus.me/2011/04/введение-в-xpath-на-примере-простого-парсе/";

            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument doc = web.Load(url);

            ////HtmlNodeCollection bodyNode = doc.DocumentNode.SelectNodes("//div[contains(@class,'page_info_wrap ')]");
            //HtmlNodeCollection bodyNode = doc.DocumentNode.SelectNodes("//a");

            //if (bodyNode != null)
            //{
            //    //for (int i = 0; i <= 5; i++)
            //    //{
            //        foreach (var tag in bodyNode)
            //        {
            //            MessageBox.Show(tag.InnerText);
            //            //textBoxInf.Text = tag.InnerText;
            //        }
            //        //textBoxInf.Text = bodyNode.ToString();
            //  // }
            //}
            //else MessageBox.Show("Нет данных");
            //////$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            //получение запроса через get 
            //textBoxInf
            //57451514
            //string iduserss = textBoxInf.Text;
            string iduserss = "57451514";

            string sURL;
            sURL = ("https://api.vk.com/method/users.get?&user_ids="+iduserss+"&lang=ru&fields=city,bdate,education,schools,sex,about,activities,books,connections,contacts,counters,country,exports,has_mobile&access_token=16ddbd5616ddbd5616ddbd561816a9756d116dd16ddbd564978d1b8d880aadef9c04c47&v=5.124");
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            //
            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    //MessageBox.Show(sLine.ToString());
                    textBoxInf.Text = sLine.ToString();
            }


           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           

        }

        private void bt_otp_Loaded(object sender, RoutedEventArgs e)
        {
            //WebRequest rec = WebRequest.Create(@"https://vk.com/id57451514");
            //rec.Method = "POST";

            //// rec.ContentType = "application/x-www-urlencoded";

            //WebResponse response = rec.GetResponse();
            //using (Stream s = response.GetResponseStream())
            //{
            //    using (StreamReader r = new StreamReader(s))
            //    {
            //        textBoxInf.Text = r.ReadToEnd();
            //    }
            //}
            //response.Close();
           


        }
    }
}
