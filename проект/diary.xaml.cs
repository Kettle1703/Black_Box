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
    
    public partial class diary : Page
    {
        public void Update_diary()
        {
            story.Text = experience.all_text;
            ScrollViewer.ScrollToEnd();
        }

        public diary()
        {
            InitializeComponent();
            MainWindow.chapter = 4;
            Update_diary();
            
        }

        private void DairyBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }

        private void Go_to_exam(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new exam());
        }
        private void Go_to_experience(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new experience());
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            ScrollViewer.Focus();
            if (e.Key == Key.Up)
            {
                ScrollViewer.LineUp();
            }
           
            if (e.Key == Key.Down)
            { 
                ScrollViewer.LineDown();
            }
        }

        
    }
}
