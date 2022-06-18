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
using Microsoft.Win32;
using System.IO;

namespace Calanthe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Student user = new Student();
        CalantheEntities db = new CalantheEntities();

        public Registration()
        {
            InitializeComponent();
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Autorization _win = new Autorization();
            this.Close();
            _win.Show();
        }

        private void Continue_b_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            byte[] buffer;
            buffer = System.IO.File.ReadAllBytes(@"ziro_foto.png");

            if (Password.Text == "" || Login.Text == "" || Mail.Text == "") MessageBox.Show("No ha introducido todos los datos!");

            else
            {
                foreach (var item in db.Student)
                {
                    if (item.Email == Mail.Text)
                    {
                        user = item;
                        n = 1;
                    }
                }
                if (n == 0)
                {
                    string[] dataLogin = Mail.Text.Split('@');
                    if (dataLogin.Length == 2)
                    {
                        string[] data2Login = dataLogin[1].Split('.');
                        if (data2Login.Length == 2)
                        {
                            if (Password.Text.Length >= 8)
                            {  
                                user.Email = Mail.Text.Trim();
                                user.Login = Login.Text.Trim();
                                user.Password = Password.Text.Trim();
                                user.Image = buffer;
                                db.Student.Add(user);
                                db.SaveChanges();

                                Statistics statistic;
                                for (int i = 0; i < 16; i++)
                                {
                                    statistic = new Statistics(Mail.Text, i + 1, "Не пройдено", "Не пройдено");
                                    db.Statistics.Add(statistic);
                                }
                                db.SaveChanges();

                                Autorization _win = new Autorization();
                                this.Close();
                                _win.Show();
                            }
                            else MessageBox.Show("La contraseña debe ser de más de 8 caracteres!");
                        }
                        else MessageBox.Show("El correo electrónico debe estar en formato: .. @ .. . ..!");
                    }
                    else MessageBox.Show("El correo electrónico debe estar en formato: .. @ .. . ..!");
                }
                if(n == 1) MessageBox.Show("Este correo ya ha sido usado!");
            }
        }

        private void eye_Click(object sender, RoutedEventArgs e)
        {
            if (Password_pb.Visibility == Visibility.Visible)
            {
                Password_pb.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Visible;
                Password.Text = Password_pb.Password;
            }
            else
            {
                Password_pb.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                Password_pb.Password = Password.Text;
            }
        }
    }
    
}

