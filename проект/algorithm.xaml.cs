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
    /// Логика взаимодействия для algorithm.xaml
    /// </summary>
    public partial class algorithm : Page
    {
        public static int algorithm_number = 1;
        public algorithm()
        {
            InitializeComponent();
        }

        private void Check_input()
        {
            int number;
            bool flag = int.TryParse(input.Text, out number);
            if(flag)
            {
                if (number >= 1 && number <= 29)
                {
                    algorithm_number = number;
                    output.Text = $"Номер выбранного алгоритма {number}";
                }
                else
                    output.Text = "Нет алгоритма с таким номером";
            }
            else
                output.Text = "Не корректные входные данные";
        }
        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Check_input();
            if(e.Key == Key.Escape)
                AlgorihmBack_Click(sender, e);
                
        }

        private void AlgorihmBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }
    }
}
