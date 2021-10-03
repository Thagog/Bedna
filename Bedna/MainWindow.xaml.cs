using System;
using System.Collections.Generic;
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
using System.Threading;
namespace Bedna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int kredit = 0;
        public int kredit2 = 0;
        public int typ;
        public bool nedostatekH = false;
        public MainWindow()
        {
            InitializeComponent();
            string hovno = this.CenaRoztoceni.SelectedItem.ToString();
            string[] s = hovno.Split(' ');
            typ = int.Parse(s[s.Length - 1]);

        }

        private void VlozKr_Click(object sender, RoutedEventArgs e)
        {

            bool spatnezadani = false;
            bool jecislo = int.TryParse(Hotovost.Text, out _);
            if (jecislo == false)
            {
                MessageBox.Show("špatně zadaná hodnota");
                Hotovost.Text = "";
            }
            else
            {
                if (int.Parse(Hotovost.Text) < 0)
                {
                    MessageBox.Show("špatně zadaná hodnota");
                    spatnezadani = true;


                }
                if (spatnezadani == true)
                {
                    MessageBox.Show("špatně zadaná hodnota");
                }
                else
                {

                    int hot = int.Parse(Hotovost.Text);
                    int kredit = int.Parse(AktKredit.Text) + hot;
                    AktKredit.Text = kredit.ToString();

                    int hot2 = int.Parse(Hotovost.Text);
                    int kredit2 = int.Parse(CelkemVHZ.Text) + hot2;
                    CelkemVHZ.Text = kredit2.ToString();
                }

            }


        }

        private void VyberKr_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vzal sis " + kredit + ".- Kč, cg");
            AktKredit.Text = "0";
            Hotovost.Text = "0";
        }

        private void ROZTOC_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(AktKredit.Text) < 10)
            {
                MessageBox.Show("Nedostatek hotovosti");
                nedostatekH = true;

            }
            if (nedostatekH == true)
            {
                if (int.Parse(AktKredit.Text) >= 10)
                {
                    nedostatekH = false;
                }
            }
            string curritem = this.CenaRoztoceni.SelectedItem.ToString();
            string[] s = curritem.Split(' ');
            typ = int.Parse(s[s.Length - 1]);
            Random random = new Random();
            int obrazek1 = random.Next(1, 8);
            int obrazek2 = random.Next(1, 8);
            int obrazek3 = random.Next(1, 8);
            if (int.Parse(AktKredit.Text) < typ)
            {
                MessageBox.Show("Nedostatek hotovosti");
                return;
                
            }
            else
            {
                kredit = int.Parse(AktKredit.Text) - typ;
                AktKredit.Text = kredit.ToString();
            }
            if (nedostatekH == false)
            {
                Switche(obr1, obrazek1);
                Switche(obr2, obrazek2);
                Switche(obr3, obrazek3);
                
                if (typ == 10)
                {
                    Prosim(10, 1, obrazek1, obrazek2, obrazek3);
             
                }
                else if (typ == 25)
                {
                    Prosim(25, 2, obrazek1, obrazek2, obrazek3);

                }
                else if (typ == 50)
                {
                    Prosim(50, 5, obrazek1, obrazek2, obrazek3);
                }               
                else if (typ == 100)
                {
                    Prosim(100, 10, obrazek1, obrazek2, obrazek3);

                }

            }


        }
        private BitmapImage GetImgSrc(string url)
        {
            BitmapImage bollocks = new BitmapImage();
            bollocks.BeginInit();
            bollocks.UriSource = new Uri(url);
            bollocks.EndInit();
            return bollocks;
        }
        public void Prosim(int type, int multiplier, int obrazek1, int obrazek2, int obrazek3)
        {
            if (typ == type)
            {

                if (obrazek1 == obrazek2 & obrazek2 == obrazek3)
                {
                    kredit += 200*multiplier;
                    AktKredit.Text = kredit.ToString();
                    MessageBox.Show("Jackpot");

                }
                else if ((obrazek1 == obrazek2) | (obrazek2 == obrazek3) | (obrazek3 == obrazek1))
                {
                    if ((obrazek1 == 3 && obrazek2 == 3) | (obrazek2 == 3 && obrazek3 == 3) | (obrazek3 == 3 && obrazek1 == 3))
                    {
                        kredit += 100*multiplier;
                        AktKredit.Text = kredit.ToString();
                    }
                    kredit += 50*multiplier;
                    AktKredit.Text = kredit.ToString();
                }

            }
        }
        public void Switche(dynamic odkaz, int vyber)
        {
            switch (vyber)
            {
                case 1:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\burger.jpeg");
                    break;
                case 2:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\citron.jpg");
                    break;
                case 3:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\hvezda.jpg");
                    break;
                case 4:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\jabko.jpg");
                    break;
                case 5:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\pizza.jfif");
                    break;
                case 6:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\pomeranc.jpg");
                    break;
                case 7:
                    odkaz.Source = GetImgSrc(@"C:\Users\kubam\Pictures\obrazky\romanknize.jpeg");
                    break;
            }
        }
    }
}
