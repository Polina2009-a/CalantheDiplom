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
        String count = "";

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
            PeacticAdjectives.Visibility = Visibility.Hidden;
            PeacticPronouns.Visibility = Visibility.Hidden;
            PeacticVerbs1.Visibility = Visibility.Hidden;
            PeacticVerbs2.Visibility = Visibility.Hidden;
            PeacticAccusative.Visibility = Visibility.Hidden;
            PeacticDative.Visibility = Visibility.Hidden;
            PeacticGenitive.Visibility = Visibility.Hidden;
            PeacticAblative.Visibility = Visibility.Hidden;
            PeacticPrepositional.Visibility = Visibility.Hidden;
            PeacticPast.Visibility = Visibility.Hidden;
            PeacticFuture.Visibility = Visibility.Hidden;
            PeacticParticles.Visibility = Visibility.Hidden;
            PeacticQuestions.Visibility = Visibility.Hidden;
            PeacticPrepositions.Visibility = Visibility.Hidden;
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
                    var statAlphabet = db.Answers.Where(p => p.NumberLesson == 1);
                    foreach (Answers p in statAlphabet)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Nouns":
                    PeacticNouns.Visibility = Visibility.Visible;
                    var statNouns = db.Answers.Where(p => p.NumberLesson == 2);
                    foreach (Answers p in statNouns)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Adjectives":
                    PeacticAdjectives.Visibility = Visibility.Visible;
                    var statAdjectives = db.Answers.Where(p => p.NumberLesson == 3);
                    foreach (Answers p in statAdjectives)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Pronouns":
                    PeacticPronouns.Visibility = Visibility.Visible;
                    var statPronouns = db.Answers.Where(p => p.NumberLesson == 4);
                    foreach (Answers p in statPronouns)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Verbs1":
                    PeacticVerbs1.Visibility = Visibility.Visible;
                    var statVerbs1 = db.Answers.Where(p => p.NumberLesson == 5);
                    foreach (Answers p in statVerbs1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Verbs2":
                    PeacticVerbs2.Visibility = Visibility.Visible;
                    var statVerbs2 = db.Answers.Where(p => p.NumberLesson == 6);
                    foreach (Answers p in statVerbs2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    MessageBox.Show(count);
                    break;
                case "Accusative":
                    PeacticAccusative.Visibility = Visibility.Visible;
                    var statAccusative = db.Answers.Where(p => p.NumberLesson == 7);
                    foreach (Answers p in statAccusative)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Dative":
                    PeacticDative.Visibility = Visibility.Visible;
                    var statDative = db.Answers.Where(p => p.NumberLesson == 8);
                    foreach (Answers p in statDative)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Genitive":
                    PeacticGenitive.Visibility = Visibility.Visible;
                    var statGenitive = db.Answers.Where(p => p.NumberLesson == 9);
                    foreach (Answers p in statGenitive)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Ablative":
                    PeacticAblative.Visibility = Visibility.Visible;
                    var statAblative = db.Answers.Where(p => p.NumberLesson == 10);
                    foreach (Answers p in statAblative)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Prepositional":
                    PeacticPrepositional.Visibility = Visibility.Visible;
                    var statPrepositional = db.Answers.Where(p => p.NumberLesson == 11);
                    foreach (Answers p in statPrepositional)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Past":
                    PeacticPast.Visibility = Visibility.Visible;
                    var statPast = db.Answers.Where(p => p.NumberLesson == 12);
                    foreach (Answers p in statPast)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Future":
                    PeacticFuture.Visibility = Visibility.Visible;
                    var statFuture = db.Answers.Where(p => p.NumberLesson == 13);
                    foreach (Answers p in statFuture)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Particles":
                    PeacticParticles.Visibility = Visibility.Visible;
                    var statParticles = db.Answers.Where(p => p.NumberLesson == 14);
                    foreach (Answers p in statParticles)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Questions":
                    PeacticQuestions.Visibility = Visibility.Visible;
                    var statQuestions = db.Answers.Where(p => p.NumberLesson == 15);
                    foreach (Answers p in statQuestions)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
                case "Prepositions":
                    PeacticPrepositions.Visibility = Visibility.Visible;
                    var statPrepositions = db.Answers.Where(p => p.NumberLesson == 16);
                    foreach (Answers p in statPrepositions)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            count += p.Answer;
                            break;
                        }
                    }
                    break;
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
        
        private void SavePeacticAlphabet_Click(object sender, RoutedEventArgs e)
        {

            if (PeacticAlphabet1.Text == "" || PeacticAlphabet2.Text == "" || PeacticAlphabet3.Text == "" || PeacticAlphabet4.Text == "" || PeacticAlphabet5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else 
            {
                string answer = PeacticAlphabet1.Text + PeacticAlphabet2.Text + PeacticAlphabet3.Text + PeacticAlphabet4.Text + PeacticAlphabet5.Text;
                if (answer == count)
                {        
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

        private void SavePeacticNouns_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticNouns1.Text == "" || PeacticNouns2.Text == "" || PeacticNouns3.Text == "" || PeacticNouns4.Text == "" || PeacticNouns5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticNouns1.Text + PeacticNouns2.Text + PeacticNouns3.Text + PeacticNouns4.Text + PeacticNouns5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticNouns1.Text = string.Empty;
                    PeacticNouns2.Text = string.Empty;
                    PeacticNouns3.Text = string.Empty;
                    PeacticNouns4.Text = string.Empty;
                    PeacticNouns5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticAdjectives_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticAdjectives1.Text == "" || PeacticAdjectives2.Text == "" || PeacticAdjectives3.Text == "" || PeacticAdjectives4.Text == "" || PeacticAdjectives5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticAdjectives1.Text + PeacticAdjectives2.Text + PeacticAdjectives3.Text + PeacticAdjectives4.Text + PeacticAdjectives5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticAdjectives1.Text = string.Empty;
                    PeacticAdjectives2.Text = string.Empty;
                    PeacticAdjectives3.Text = string.Empty;
                    PeacticAdjectives4.Text = string.Empty;
                    PeacticAdjectives5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticPronouns_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticPronouns1.Text == "" || PeacticPronouns2.Text == "" || PeacticPronouns3.Text == "" || PeacticPronouns4.Text == "" || PeacticPronouns5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticPronouns1.Text + PeacticPronouns2.Text + PeacticPronouns3.Text + PeacticPronouns4.Text + PeacticPronouns5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticPronouns1.Text = string.Empty;
                    PeacticPronouns2.Text = string.Empty;
                    PeacticPronouns3.Text = string.Empty;
                    PeacticPronouns4.Text = string.Empty;
                    PeacticPronouns5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticVerbs1_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticVerbs11.Text == "" || PeacticVerbs12.Text == "" || PeacticVerbs13.Text == "" || PeacticVerbs14.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticVerbs11.Text + PeacticVerbs12.Text + PeacticVerbs13.Text + PeacticVerbs14.Text ;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticVerbs11.Text = string.Empty;
                    PeacticVerbs12.Text = string.Empty;
                    PeacticVerbs13.Text = string.Empty;
                    PeacticVerbs14.Text = string.Empty;
                }
            }
        }

        private void SavePeacticVerbs2_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticVerbs21.Text == "" || PeacticVerbs22.Text == "" || PeacticVerbs23.Text == "" || PeacticVerbs24.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticVerbs21.Text + PeacticVerbs22.Text + PeacticVerbs23.Text + PeacticVerbs24.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticVerbs21.Text = string.Empty;
                    PeacticVerbs22.Text = string.Empty;
                    PeacticVerbs23.Text = string.Empty;
                    PeacticVerbs24.Text = string.Empty;
                }
            }
        }

        private void SavePeacticAccusative_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticAccusative1.Text == "" || PeacticAccusative2.Text == "" || PeacticAccusative3.Text == "" || PeacticAccusative4.Text == "" || PeacticAccusative5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticAccusative1.Text + PeacticAccusative2.Text + PeacticAccusative3.Text + PeacticAccusative4.Text + PeacticAccusative5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticAccusative1.Text = string.Empty;
                    PeacticAccusative2.Text = string.Empty;
                    PeacticAccusative3.Text = string.Empty;
                    PeacticAccusative4.Text = string.Empty;
                    PeacticAccusative5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticDative_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticDative1.Text == "" || PeacticDative2.Text == "" || PeacticDative3.Text == "" || PeacticDative4.Text == "" || PeacticDative5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticDative1.Text + PeacticDative2.Text + PeacticDative3.Text + PeacticDative4.Text + PeacticDative5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticDative1.Text = string.Empty;
                    PeacticDative2.Text = string.Empty;
                    PeacticDative3.Text = string.Empty;
                    PeacticDative4.Text = string.Empty;
                    PeacticDative5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticGenitive_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticGenitive1.Text == "" || PeacticGenitive2.Text == "" || PeacticGenitive3.Text == "" || PeacticGenitive4.Text == "" || PeacticGenitive5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticGenitive1.Text + PeacticGenitive2.Text + PeacticGenitive3.Text + PeacticGenitive4.Text + PeacticGenitive5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticGenitive1.Text = string.Empty;
                    PeacticGenitive2.Text = string.Empty;
                    PeacticGenitive3.Text = string.Empty;
                    PeacticGenitive4.Text = string.Empty;
                    PeacticGenitive5.Text = string.Empty;
                }
            }
        }

        private void SavePeacticAblative_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticAblative1.Text == "" || PeacticAblative2.Text == "" || PeacticAblative3.Text == "" || PeacticAblative4.Text == "" || PeacticAblative5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticAblative1.Text + PeacticAblative2.Text + PeacticAblative3.Text + PeacticAblative4.Text + PeacticAblative5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticAblative1.Text = string.Empty;
                    PeacticAblative2.Text = string.Empty;
                    PeacticAblative3.Text = string.Empty;
                    PeacticAblative4.Text = string.Empty;
                    PeacticAblative5.Text = string.Empty;
                }
            }
        }
        private void SavePeacticPrepositional_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticPrepositional1.Text == "" || PeacticPrepositional2.Text == "" || PeacticPrepositional3.Text == "" || PeacticPrepositional4.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticPrepositional1.Text + PeacticPrepositional2.Text + PeacticPrepositional3.Text + PeacticPrepositional4.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticPrepositional1.Text = string.Empty;
                    PeacticPrepositional2.Text = string.Empty;
                    PeacticPrepositional3.Text = string.Empty;
                    PeacticPrepositional4.Text = string.Empty;
                }
            }
        }
        private void SavePeacticPast_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticPast1.Text == "" || PeacticPast2.Text == "" || PeacticPast3.Text == "" || PeacticPast4.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticPast1.Text + PeacticPast2.Text + PeacticPast3.Text + PeacticPast4.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticPast1.Text = string.Empty;
                    PeacticPast2.Text = string.Empty;
                    PeacticPast3.Text = string.Empty;
                    PeacticPast4.Text = string.Empty;
                }
            }
        }
        private void SavePeacticFuture_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticFuture1.Text == "" || PeacticFuture2.Text == "" || PeacticFuture3.Text == "" || PeacticFuture4.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticFuture1.Text + PeacticFuture2.Text + PeacticFuture3.Text + PeacticFuture4.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticFuture1.Text = string.Empty;
                    PeacticFuture2.Text = string.Empty;
                    PeacticFuture3.Text = string.Empty;
                    PeacticFuture4.Text = string.Empty;
                }
            }
        }
        private void SavePeacticParticles_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticParticles1.Text == "" || PeacticParticles2.Text == "" || PeacticParticles3.Text == "" || PeacticParticles4.Text == "" || PeacticParticles5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticParticles1.Text + PeacticParticles2.Text + PeacticParticles3.Text + PeacticParticles4.Text + PeacticParticles5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticParticles1.Text = string.Empty;
                    PeacticParticles2.Text = string.Empty;
                    PeacticParticles3.Text = string.Empty;
                    PeacticParticles4.Text = string.Empty;
                    PeacticParticles5.Text = string.Empty;
                }
            }
        }
        private void SavePeacticQuestions_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticQuestions1.Text == "" || PeacticQuestions2.Text == "" || PeacticQuestions3.Text == "" || PeacticQuestions4.Text == "" || PeacticQuestions5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticQuestions1.Text + PeacticQuestions2.Text + PeacticQuestions3.Text + PeacticQuestions4.Text + PeacticQuestions5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticQuestions1.Text = string.Empty;
                    PeacticQuestions2.Text = string.Empty;
                    PeacticQuestions3.Text = string.Empty;
                    PeacticQuestions4.Text = string.Empty;
                    PeacticQuestions5.Text = string.Empty;
                }
            }
        }
        private void SavePeacticPrepositions_Click(object sender, RoutedEventArgs e)
        {
            if (PeacticPrepositions1.Text == "" || PeacticPrepositions2.Text == "" || PeacticPrepositions3.Text == "" || PeacticPrepositions4.Text == "" || PeacticPrepositions5.Text == "") MessageBox.Show("No todos los campos están llenos!");
            else
            {
                string answer = PeacticPrepositions1.Text + PeacticPrepositions2.Text + PeacticPrepositions3.Text + PeacticPrepositions4.Text + PeacticPrepositions5.Text;
                if (answer == count)
                {
                    MessageBox.Show("Prueba aprobada!");
                    ChangeStatusPractic();
                }
                else
                {
                    MessageBox.Show("Prueba no aprobada!");
                    PeacticPrepositions1.Text = string.Empty;
                    PeacticPrepositions2.Text = string.Empty;
                    PeacticPrepositions3.Text = string.Empty;
                    PeacticPrepositions4.Text = string.Empty;
                    PeacticPrepositions5.Text = string.Empty;
                }
            }
        }
    }
}