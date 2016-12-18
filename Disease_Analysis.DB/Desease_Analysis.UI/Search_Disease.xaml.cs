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
using System.Windows.Shapes;
using Disease_Analysis.DB;

namespace Desease_Analysis.UI
{
    /// <summary>
    /// Логика взаимодействия для Search_Disease.xaml
    /// </summary>
    public partial class Search_Disease : Window
    {
        public Search_Disease()
        {
            InitializeComponent();
        }

        List<string> ListSymptoms = new List<string>();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Symptoms.Text))
            {
                var c = Symptoms.Text;

                if (!ListSymptoms.Contains(c))
                {
                    ListSymptoms.Add(c);
                    Symptoms.Text = "";

                    if (!string.IsNullOrWhiteSpace(Symptops_label.Text))
                    {
                        Symptops_label.Text = Symptops_label.Text + ", " + c;
                    }
                    else
                    {
                        Symptops_label.Text = c;
                        Cancel.Visibility = Visibility.Visible;
                        Enter.IsEnabled = true;
                    }
                }
                else
                {
                    Symptoms.Text = "";
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var c = Symptoms.Text;

            if (ListSymptoms.Contains(c))
            {
                ListSymptoms.Remove(c);

                Symptops_label.Text = "";

                foreach (var item in ListSymptoms)
                {
                    if (!string.IsNullOrWhiteSpace(Symptops_label.Text))
                    {
                        Symptops_label.Text = Symptops_label.Text + ", " + item;
                    }
                    else
                    {
                        Symptops_label.Text = item;
                    }
                }

                if (Symptops_label.Text == "")
                {
                    Cancel.Visibility = Visibility.Hidden;
                    Enter.IsEnabled = false;
                }

                Symptoms.Text = "";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            using (var c = new Context())
            {
                List<string> ListAdd = new List<string>();

                foreach (var item in c.Disease)
                {
                    int x = 0;
                    foreach (var sym in ListSymptoms)
                    {
                        string[] a = item.symptoms.Split('|');
                        foreach (var b in a)
                        {
                            if (b == sym)
                            {
                                x++;
                            }
                        }
                    }
                    if (x == ListSymptoms.Count)
                    {
                        ListAdd.Add(item.disease);
                    }
                }

                foreach (var symptop in ListAdd)
                {
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        textBox1.Text = textBox1.Text + ", " + symptop;
                    }
                    else
                    {
                        textBox1.Text = symptop;
                    }
                }

                if (textBox1.Text == "")
                {
                    textBox1.Text = "Заболевания с такими симптомами не существует";
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            Close();
            log.ShowDialog();
        }
    }
}
