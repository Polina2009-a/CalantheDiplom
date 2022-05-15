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

            if (Mail.Text == "" || Password.Password.ToString() == "") MessageBox.Show("Введите данные!");

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
                    MessageBox.Show("Добро пожаловать!");
                }
                else MessageBox.Show("Такого пользователя не существует!");
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = 0;
                if (Mail.Text == "") MessageBox.Show("Введите почту, а потом нажмите сюда ещё раз!");
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
                        m.Subject = "Восстановление пароля";
                        m.Body = "Ваш новый пароль:" + finalString;
                        m.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                        smtp.Credentials = new NetworkCredential("Polina_alekseevna_valova@mail.ru", "D3vTLNZE6CBLNB4dKAEG");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        MessageBox.Show("Пароль отправлен на Вашу почту! После его получения авторизуйтесь с помощью него!");

                        _user.Password = finalString;
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Пользователя с такой электронной почтой не существует!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет подключения к интернету или такой почты не существует!");
            }
        }  
    }
}