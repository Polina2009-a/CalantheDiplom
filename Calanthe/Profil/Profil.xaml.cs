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
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    break;
                case 6:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    break;
                case 7:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    break;
                case 8:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    break;
                case 9:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    break;
                case 10:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    break;
                case 11:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    break;
                case 12:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    rcg12.Fill = Brushes.Fuchsia;
                    break;
                case 13:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    rcg12.Fill = Brushes.Fuchsia;
                    rcg13.Fill = Brushes.GreenYellow;
                    break;
                case 14:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    rcg12.Fill = Brushes.Fuchsia;
                    rcg13.Fill = Brushes.GreenYellow;
                    rcg14.Fill = Brushes.GreenYellow;
                    break;
                case 15:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    rcg12.Fill = Brushes.Fuchsia;
                    rcg13.Fill = Brushes.GreenYellow;
                    rcg14.Fill = Brushes.GreenYellow;
                    rcg15.Fill = Brushes.GreenYellow;
                    break;
                case 16:
                    rcg1.Fill = Brushes.Blue;
                    rcg2.Fill = Brushes.Blue;
                    rcg3.Fill = Brushes.Blue;
                    rcg4.Fill = Brushes.Blue;
                    rcg5.Fill = Brushes.Goldenrod;
                    rcg6.Fill = Brushes.Goldenrod;
                    rcg7.Fill = Brushes.Goldenrod;
                    rcg8.Fill = Brushes.Goldenrod;
                    rcg9.Fill = Brushes.Fuchsia;
                    rcg10.Fill = Brushes.Fuchsia;
                    rcg11.Fill = Brushes.Fuchsia;
                    rcg12.Fill = Brushes.Fuchsia;
                    rcg13.Fill = Brushes.GreenYellow;
                    rcg14.Fill = Brushes.GreenYellow;
                    rcg15.Fill = Brushes.GreenYellow;
                    rcg16.Fill = Brushes.GreenYellow;
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
