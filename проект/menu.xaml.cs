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

namespace проект
{
    /// <summary>
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        public menu()
        {
            InitializeComponent();
        }

        private void Algorithm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new algorithm());
        }

        private void Experience_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new experience());
        }

        private void Exam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new exam());
        }

        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new diary());
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new calculator());
        }
    }
}
