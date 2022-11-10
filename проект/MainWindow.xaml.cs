using System.Windows;
using System;

namespace проект
{
    public partial class MainWindow : Window
    {
        public static string save_input_in_calc;
        public static string save_output_in_calc;
        public static bool first_change_algorithm = true;
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new menu();
        }
    }
}
