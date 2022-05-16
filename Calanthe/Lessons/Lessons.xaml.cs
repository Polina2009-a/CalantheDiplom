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
    public partial class Lessons : Window
    {
        string mail;
        CalantheEntities db = new CalantheEntities();
        TheoreticalLesson theoreticalLesson = new TheoreticalLesson();
        Statistics statistics = new Statistics();
        Answers answers = new Answers();
        string filename = null;
        string msg;
        string Answer;

        public Lessons(string mail)
        {
            InitializeComponent();
            this.mail = mail;
            
        }

        private void Back_b_Click(object sender, RoutedEventArgs e)
        {
            Menu _win = new Menu(mail);
            this.Close();
            _win.Show();
        }

        private void Dictionary_b_Click(object sender, RoutedEventArgs e)
        {
            Dictionary _win = new Dictionary(mail);
            this.Close();
            _win.Show();
        }

        private void ViewLesson(object sender, RoutedEventArgs e)
        {
            msg = ((Button)sender).Name;
            PanelMenu.Visibility = Visibility.Visible;
            Dictionary_b.Visibility = Visibility.Visible;
            Dictionary_b.Visibility = Visibility.Visible;
            Back_b2.Visibility = Visibility.Visible;
            Back_b.Visibility = Visibility.Hidden;
            PanelLessons.Visibility = Visibility.Hidden;
        }

        private void Back_b2_Click(object sender, RoutedEventArgs e)
        {
            PanelMenu.Visibility = Visibility.Hidden;
            Dictionary_b.Visibility = Visibility.Hidden;
            Dictionary_b.Visibility = Visibility.Hidden;
            Back_b2.Visibility = Visibility.Hidden;
            Back_b.Visibility = Visibility.Visible;
            PanelLessons.Visibility = Visibility.Visible;
        }  

        private void Back_b3_Click(object sender, RoutedEventArgs e)
        {
            PeacticAlphabet.Visibility = Visibility.Hidden;
            PeacticNouns.Visibility = Visibility.Hidden;
            Back_b3.Visibility = Visibility.Hidden;
            Back_b2.Visibility = Visibility.Visible;
            PanelMenu.Visibility = Visibility.Visible;
            Dictionary_b.Visibility = Visibility.Visible;
        }

        private void Teoria_b_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            Statistics statistics = new Statistics();
            try
            {
                foreach (var item in db.TheoreticalLesson)
                {
                    if (msg == item.Title)
                    {
                        theoreticalLesson = item;

                        MessageBox.Show("Por favor, seleccione la carpeta para guardar el archivo!");
                        using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                        {
                            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                            filename = dialog.SelectedPath + @"\" + msg + ".pdf";
                        }

                        File.WriteAllBytes(filename, theoreticalLesson.FileLesson);
                        var process = Process.Start(filename);

                        foreach (var i in db.Statistics)
                        {
                            if (item.Number == i.NumberLesson && i.Email == mail)
                            {
                                i.StatusTeoria = "Пройдено";
                                break;
                            }
                        }
                    }
                }
                db.SaveChanges();
            }

            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void Practic_b_Click(object sender, RoutedEventArgs e)
        {
            Back_b3.Visibility = Visibility.Visible;
            Back_b.Visibility = Visibility.Hidden;
            PanelLessons.Visibility = Visibility.Hidden;
            Dictionary_b.Visibility = Visibility.Hidden;
            PanelMenu.Visibility = Visibility.Hidden;
            MessageBox.Show("Por favor escriba todas las respuestas en letra minúscula!");
            
            switch (msg)
            {
                case "Alphabet":
                    PeacticAlphabet.Visibility = Visibility.Visible;
                    break;
                case "Nouns":
                    PeacticNouns.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SavePeacticAlphabet_Click(object sender, RoutedEventArgs e)
        {

            if (PeacticAlphabet1.Text == "" || PeacticAlphabet2.Text == "" || PeacticAlphabet3.Text == "" || PeacticAlphabet4.Text == "" || PeacticAlphabet5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else 
            {
                if (PeacticAlphabet1.Text == "33" && PeacticAlphabet2.Text == "я" && PeacticAlphabet3.Text == "1001" && PeacticAlphabet4.Text == "6" && PeacticAlphabet5.Text == "она")
                {
                    string answer = PeacticAlphabet1.Text + PeacticAlphabet2.Text + PeacticAlphabet3.Text + PeacticAlphabet4.Text + PeacticAlphabet5.Text;;
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticAlphabet1.Text = string.Empty;
                    PeacticAlphabet2.Text = string.Empty;
                    PeacticAlphabet3.Text = string.Empty;
                    PeacticAlphabet4.Text = string.Empty;
                    PeacticAlphabet5.Text = string.Empty;
                }
            }
        }

        void ChangeStatusPractic()
        {
            Statistics statistics = new Statistics();
                foreach (var item in db.TheoreticalLesson)
                {
                    if (msg == item.Title)
                    {
                        foreach (var i in db.Statistics)
                        {
                            if (item.Number == i.NumberLesson && i.Email == mail)
                            {
                                i.StatusPractic = "Пройдено";
                                break;
                            }
                        }
                    }
                }
           db.SaveChanges();
        }
    }
}