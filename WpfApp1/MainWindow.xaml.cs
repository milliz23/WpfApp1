using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "Base.csv";  // путь k файлу
        List<People> ListPeople = new List<People>();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                BtnShow.IsEnabled = true;
            }
        }

        private void BTsumm_Click(object sender, RoutedEventArgs e)// расчитываем сумму поездки
        {
            try
            {
               if (RBGr.IsChecked==true)
               {
                double summ = ((0.33 * Convert.ToDouble(TBKm.Text)) * 45.55)+ (Convert.ToDouble(TBKm.Text)*10)+5;
                    if(summ<150)
                    {
                        TBsumm.Text = "150 рублей" ;
                    }
                    if (summ > 150) { TBsumm.Text = ""+summ+" рублей"; }
                   
               }
                if(RBLg.IsChecked==true)
                {
                    double litr = 0.12 * Convert.ToDouble(TBKm.Text)*45.55;
                    double summ = litr + Convert.ToDouble(TBKm.Text) * 10 + 5;
                    TBsumm.Text = "" + summ + " рублей";
                    if (summ < 150)
                    {
                        TBsumm.Text = "150 рублей";
                    }
                    if (summ > 150) { TBsumm.Text = "" + summ + " рублей"; }
                }
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных");
            }                   
        }
        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            Im.Visibility = Visibility.Visible;
            SPShow.Visibility = Visibility.Collapsed;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(TBName.Text + ";");
                sw.Write(TBNamevod.Text + ";");
                sw.Write(DPDr.SelectedDate.ToString() + ";");
                if (RBLg.IsChecked == true)
                {
                    sw.Write("Легковой" + ";");
                }
                if (RBGr.IsChecked == true)
                {
                    sw.Write("Грузовой" + ";");
                }
                sw.Write(TBOtp.Text + ";");
                sw.Write(TBprib.Text + ";");
                sw.Write(TBKm.Text + ";");
                sw.Write(TBsumm.Text + "\n");      
                MessageBox.Show("Данные записаны");
                BtnShow.IsEnabled = true;
                TBName.Text = "";
                TBNamevod.Text = "";
                DPDr.Text = null;
                RBGr.IsChecked = false;
                RBLg.IsChecked = false;
                TBOtp.Text = "";
                TBprib.Text = "";
                TBKm.Text = "";
                TBsumm.Text = "";
            }
        }
        int i;
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            Im.Visibility = Visibility.Collapsed;
            SPShow.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Sarr = sr.ReadLine().Split(';');
                    ListPeople.Add(new People()
                    { Name = Sarr[0], Namevod = Sarr[1], DPDr = Sarr[2], Type = Sarr[3], Otpr = Sarr[4], Prib=Sarr[5], Km=Sarr[6], Summ=Sarr[7]});
                }
                i = 0;
                TBShowName.Text = ListPeople[0].Name;
                TBShowVod.Text = ListPeople[0].Namevod;
                TBShowDT.Text = ListPeople[0].DPDr;
                TBShowavto.Text = ListPeople[0].Type;
                TBShowotpr.Text = ListPeople[0].Otpr;          
                TBShowdost.Text = ListPeople[0].Prib;
                TBShowkm.Text = ListPeople[0].Km;
                TBShowsumm.Text = ListPeople[0].Summ;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i++;
                TBShowName.Text = ListPeople[i].Name;
                TBShowVod.Text = ListPeople[i].Namevod;
                TBShowDT.Text = ListPeople[i].DPDr;
                TBShowavto.Text = ListPeople[i].Type;
                TBShowotpr.Text = ListPeople[i].Otpr;
                TBShowdost.Text = ListPeople[i].Prib;
                TBShowkm.Text = ListPeople[i].Km;
                TBShowsumm.Text = ListPeople[i].Summ;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                i = ListPeople.Count - 1;
                TBShowName.Text = ListPeople[i].Name;
                TBShowVod.Text = ListPeople[i].Namevod;
                TBShowDT.Text = ListPeople[i].DPDr;
                TBShowavto.Text = ListPeople[i].Type;
                TBShowotpr.Text = ListPeople[i].Otpr;
                TBShowdost.Text = ListPeople[i].Prib;
                TBShowkm.Text = ListPeople[i].Km;
                TBShowsumm.Text = ListPeople[i].Summ;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                i--;
                TBShowName.Text = ListPeople[i].Name;
                TBShowVod.Text = ListPeople[i].Namevod;
                TBShowDT.Text = ListPeople[i].DPDr;
                TBShowavto.Text = ListPeople[i].Type;
                TBShowotpr.Text = ListPeople[i].Otpr;
                TBShowdost.Text = ListPeople[i].Prib;
                TBShowkm.Text = ListPeople[i].Km;
                TBShowsumm.Text = ListPeople[i].Summ;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                
                TBShowName.Text = ListPeople[0].Name;
                TBShowVod.Text = ListPeople[0].Namevod;
                TBShowDT.Text = ListPeople[0].DPDr;
                TBShowavto.Text = ListPeople[0].Type;
                TBShowotpr.Text = ListPeople[0].Otpr;
                TBShowdost.Text = ListPeople[0].Prib;
                TBShowkm.Text = ListPeople[0].Km;
                TBShowsumm.Text = ListPeople[0].Summ;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }
    }
} 
