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
    /// Логика взаимодействия для AddToDB.xaml
    /// </summary>
    public partial class AddToDB : Window
    {
        public AddToDB()
        {
            InitializeComponent();
        }

        List<string> ListSymptoms = new List<string>();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Disease.Text))
            {
                Disease.Visibility = Visibility.Hidden;
                button.Visibility = Visibility.Hidden;

                Name.Text = Disease.Text;
                Name.Visibility = Visibility.Visible;
                Cancel_1.Visibility = Visibility.Visible;

                Description.Visibility = Visibility.Visible;
                button_2.Visibility = Visibility.Visible;
                label1.IsEnabled = true;
            }
        }

        private void Cancel_1_Click(object sender, RoutedEventArgs e)
        {
            Disease.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;

            Name.Visibility = Visibility.Hidden;
            Cancel_1.Visibility = Visibility.Hidden;

            Description.Visibility = Visibility.Hidden;
            button_2.Visibility = Visibility.Hidden;
            label1.IsEnabled = false;
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Description.Text))
            {
                Description.Visibility = Visibility.Hidden;
                button_2.Visibility = Visibility.Hidden;
                Cancel_1.Visibility = Visibility.Hidden;

                Description_label.Text = Description.Text;
                Description_label.Visibility = Visibility.Visible;
                Cancel_2.Visibility = Visibility.Visible;

                Symptoms.Visibility = Visibility.Visible;
                button_3.Visibility = Visibility.Visible;
                Symptops_label.Visibility = Visibility.Visible;
                label2.IsEnabled = true;
            }
        }

        private void Cancel_2_Click(object sender, RoutedEventArgs e)
        {
            Description.Visibility = Visibility.Visible;
            button_2.Visibility = Visibility.Visible;
            Cancel_1.Visibility = Visibility.Visible;

            Description_label.Visibility = Visibility.Hidden;
            Cancel_2.Visibility = Visibility.Hidden;

            Symptoms.Visibility = Visibility.Hidden;
            button_3.Visibility = Visibility.Hidden;
            Symptops_label.Visibility = Visibility.Hidden;
            label2.IsEnabled = false;
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
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
                        Cancel_3.Visibility = Visibility.Visible;
                        Enter.IsEnabled = true;
                    }
                }
                else
                {
                    Symptoms.Text = "";
                }
            }
               
        }

        private void Cancel_3_Click(object sender, RoutedEventArgs e)
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
                    Cancel_3.Visibility = Visibility.Hidden;
                    Enter.IsEnabled = false;
                }

                Symptoms.Text = "";
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Context())
            {
                string ListAdd = null;
                foreach ( var item in ListSymptoms)
                {
                    ListAdd += item + "|";
                }

                c.Disease.Add(new Disease
                {
                    disease = Name.Text,
                    description = Description_label.Text,
                    symptoms = ListAdd
                });
                c.SaveChanges();
            }

            ListSymptoms.Clear();

            Disease.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;

            Name.Visibility = Visibility.Hidden;
            Cancel_1.Visibility = Visibility.Hidden;

            Description.Visibility = Visibility.Hidden;
            button_2.Visibility = Visibility.Hidden;
            label1.IsEnabled = false;

            Description_label.Visibility = Visibility.Hidden;
            Cancel_2.Visibility = Visibility.Hidden;

            Symptoms.Visibility = Visibility.Hidden;
            button_3.Visibility = Visibility.Hidden;
            Cancel_3.Visibility = Visibility.Hidden;
            Symptops_label.Visibility = Visibility.Hidden;
            label2.IsEnabled = false;

            Disease.Text = "";
            Description.Text = "";
            Symptoms.Text = "";
            Symptops_label.Text = "";

            MessageBox.Show("Заболевание успешно внесено в базу данных");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            Close();
            log.ShowDialog();
        }
    }
}
