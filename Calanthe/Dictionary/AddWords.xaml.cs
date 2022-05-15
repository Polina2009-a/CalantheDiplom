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

namespace Calanthe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AddWords : Window
    {
        string mail;
        private CalantheEntities _context = new CalantheEntities();
        int id;
        string Email;

        public AddWords(string mail)
        {
            InitializeComponent();
            this.mail = mail;
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Dictionary _win = new Dictionary(mail);
            _win.Show();
            this.Close();
        }

        private void Save_b_Click(object sender, RoutedEventArgs e)
        {
            Vocabulary _vocabulary = new Vocabulary();

            if (Word.Text == "" || Translite.Text == "") MessageBox.Show("Введите данные!");
            else
            {

                _vocabulary.Email = mail;
                _vocabulary.Word = Word.Text.Trim();
                _vocabulary.Translation = Translite.Text.Trim();
                _context.Vocabulary.Add(_vocabulary);

                _context.SaveChanges();

                Dictionary _win = new Dictionary(mail);
                _win.Show();
                this.Close();
                MessageBox.Show("Сохранено!");
            }

        }
    }
}
