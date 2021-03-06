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
    public partial class EditWords : Window
    {
        string mail;
        private CalantheEntities _context;
        private Vocabulary _vocabulary;
        private Dictionary dictionary;
        int id;

        public EditWords(string mail, CalantheEntities context, object o, Dictionary _dictionary)
        {
            InitializeComponent();
            this.mail = mail;
            _vocabulary = (o as Button).DataContext as Vocabulary;

            _context = context;
            dictionary = _dictionary;
            Word.Text = _vocabulary.Word;
            Translite.Text = _vocabulary.Translation;
            id = _vocabulary.ID;
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Dictionary _win = new Dictionary(mail);
            this.Close();
            _win.Show();
        }

        private void Save_b_Click(object sender, RoutedEventArgs e)
        {
            foreach (var user in _context.Vocabulary)
            {
                if (id == user.ID)
                {
                    _vocabulary = user;
                    _vocabulary.Word = Word.Text;
                    _vocabulary.Translation = Translite.Text;
                    break;
                }
            }
            _context.SaveChanges();
            MessageBox.Show("Guardado!");
            Dictionary _win = new Dictionary(mail);
            _win.Show();
            this.Close();
        }
    }
}
