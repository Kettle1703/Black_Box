using System.Windows;

namespace проект
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new menu();
        }
    }
}
