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
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Converters;

namespace Calanthe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Profil : Window
    {
        string mail;
        Student user = new Student();
        CalantheEntities db = new CalantheEntities();
        Statistics statistics = new Statistics();
        string filename = null;
        int count = 0;

        public Profil(string mail)
        {
            InitializeComponent();
            this.mail = mail;     
            foreach (var user in db.Student)
            {
                if (mail == user.Email)
                {
                    imageEllipse.Fill = new ImageBrush(LoadImage(user.Image));
                    break;
                }
            }

            var stat = db.Statistics.Where(p => p.Email == mail && p.StatusPractic == "Пройдено" && p.StatusTeoria == "Пройдено");                    
            foreach(Statistics p in stat)
            {
                for (int i = 0; i < 16; i++) 
                { 
                        count += 1;
                        break;
                }                      
            }

            switch (count)
            {
                case 1:
                    rcg1.Fill = Brushes.Blue;
                    break;
                case 2:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    break;
                case 3:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    break;
                case 4:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
            }
        }

        private void Continue_b_Click(object sender, RoutedEventArgs e)
        {
            EditProfil _win = new EditProfil(mail);
            this.Close();
            _win.Show();
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Menu _win = new Menu(mail);
            this.Close();
            _win.Show();
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
