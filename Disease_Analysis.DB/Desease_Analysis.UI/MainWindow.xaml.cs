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
using Disease_Analysis.DB;

namespace Desease_Analysis.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddToDB log = new AddToDB();
            Close();
            log.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Search_Disease log = new Search_Disease();
            Close();
            log.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
