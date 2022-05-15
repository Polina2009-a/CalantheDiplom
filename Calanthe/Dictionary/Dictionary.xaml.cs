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
    public partial class Dictionary : Window
    {
        string mail;
        CalantheEntities _context = new CalantheEntities();
        public Dictionary(string mail)
        {
            InitializeComponent();
            this.mail = mail;
            dbWords.ItemsSource = _context.Vocabulary.ToList();      
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Menu _win = new Menu(mail);
            this.Close();
            _win.Show();
        }

        private void Add_b_Click(object sender, RoutedEventArgs e)
        {
            AddWords _win = new AddWords(mail);
            this.Close();
            _win.Show();
        }

        private void Back_lessons_Click(object sender, RoutedEventArgs e)
        {
            Lessons _win = new Lessons(mail);
            this.Close();
            _win.Show();
        }

        private void edit_b_Click_1(object sender, RoutedEventArgs e)
        {
            EditWords _win = new EditWords(mail, _context, sender, this);
            _win.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var current_item = CalantheEntities.GetContext().Vocabulary.ToList();
            current_item = current_item.Where(p => p.Email.ToString().ToLower().Contains(mail.ToLower())).ToList();
            CalantheEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dbWords.ItemsSource = current_item;
        }

        private void del_b_Click(object sender, RoutedEventArgs e)
        {
            DelWords _win = new DelWords(mail, _context, sender, this);
            _win.Show();
            this.Close();
        }

        private void tbResearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (tbResearch.Text == string.Empty) 
            {
            var current_item1 = CalantheEntities.GetContext().Vocabulary.ToList();
            current_item1 = current_item1.Where(p => p.Email.ToString().ToLower().Contains(mail.ToLower())).ToList();
            dbWords.ItemsSource = current_item1;
            }

            else
            {
                var current_item = CalantheEntities.GetContext().Vocabulary.ToList();
                current_item = current_item.Where(p => p.Word.ToString().ToLower().Contains(tbResearch.Text.ToLower())).ToList();
                dbWords.ItemsSource = current_item;
            }
        }
    }
}
