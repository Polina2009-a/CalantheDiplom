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
using System.Web;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace Calanthe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        Student _user = new Student();
        CalantheEntities db = new CalantheEntities();

        public Autorization()
        {
            InitializeComponent();
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _win = new MainWindow();
            this.Close();
            _win.Show();
        }

        private void registration_b_Click_1(object sender, RoutedEventArgs e)
        {
            Registration _win = new Registration();
            this.Close();
            _win.Show();
        }

        private void Continue_b_Click_1(object sender, RoutedEventArgs e)
        {
            int n = 0;

            if (Mail.Text == "" || Password.Password.ToString() == "") MessageBox.Show("Introduzca los datos!");

            else
            {
                foreach (var user in db.Student)
                {
                    if (Mail.Text == user.Email && Password.Password.ToString() == user.Password)
                    {
                        n = 1;
                        break;
                    }
                }
                if (n == 1)
                {
                    Menu _win = new Menu(Mail.Text);
                    this.Close();
                    _win.Show();
                    MessageBox.Show("Bienvenido!");
                }
                else MessageBox.Show("Este usuario no existe!");
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = 0;
                if (Mail.Text == "") MessageBox.Show("Ingrese su correo electrónico y luego haga clic aquí de nuevo!");
                else
                {
                    foreach (var user in db.Student)
                    {
                        if (Mail.Text == user.Email)
                        {
                            _user = user;
                            n = 1;
                            break;
                        }
                    }

                    if (n == 1)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[8];
                        var random = new Random();
                        string finalString = "";

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                            finalString += stringChars[i];
                        }

                        MailAddress from = new MailAddress("Polina_alekseevna_valova@mail.ru", "Calanthe - Ruso Idioma");
                        MailAddress to = new MailAddress(Mail.Text);
                        MailMessage m = new MailMessage(from, to);
                        m.Subject = "Recuperación de contraseña";
                        m.Body = "Su nueva contraseña:" + finalString;
                        m.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                        smtp.Credentials = new NetworkCredential("Polina_alekseevna_valova@mail.ru", "D3vTLNZE6CBLNB4dKAEG");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        MessageBox.Show("Contraseña enviada a Su correo electrónico! Después de recibirlo, inicie sesión con él!");

                        _user.Password = finalString;
                        db.SaveChanges();
                    }
                    else MessageBox.Show("El usuario con dicho correo electrónico no existe!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexión a Internet o este correo electrónico no existe!");
            }
        }  
    }
}