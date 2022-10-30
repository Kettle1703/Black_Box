using System.Windows;

namespace проект
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Algorithm_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new algorithm();
        }

        private void Experience_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new experience();
        }

        private void Exam_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new exam();
        }

        private void Diary_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new diary();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new calculator();
        }
    }
}
