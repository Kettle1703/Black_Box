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
    
    public partial class experience : Page
    {
        private static bool Input_string(int n)  // у алгоритма с этим номером на вход строка ? 
        {
            if(n == 5 || n == 6 || n == 9 || (n >= 13 && n <= 17) || n == 25 || n == 27 || n == 29)
                return true;
            else 
                return false;
        }

        private void Check_input()
        {
            int number;
            bool flag = int.TryParse(input.Text, out number);
            if(flag)
            {
                // пользователь ввёл число и может использовать алгоритмы: 1. 2. 3. 4. 7. 8. 10. 11. 12. с 18 по 24. 26. 28
                if(!Input_string(algorithm.algorithm_number))
                {
                    //output.Text = "okey";
                    switch(algorithm.algorithm_number)
                    {
                        case 1:
                            
                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 10:

                            break;
                        case 11:

                            break;
                        case 12:

                            break;
                        case 18:

                            break;
                        case 19:

                            break;
                        case 20:

                            break;
                        case 21:

                            break;
                        case 22:

                            break;
                        case 23:

                            break;
                        case 24:

                            break;
                        case 26:

                            break;
                        case 26:

                            break;
                    }
                }
                else
                {
                    output.Text = $"Алгоритм {algorithm.algorithm_number} не обрабатывает строки";
                }
            }
            else
            {
                // пользователь ввёл строку и может использовать алгоритмы: 5. 6. 9. c 13 по 17. 25. 27. 29
                if(Input_string(algorithm.algorithm_number))
                {
                    //output.Text = "okey";
                    switch (algorithm.algorithm_number)
                    {
                        case 5:

                            break;
                        case 6:

                            break;
                        case 9:

                            break;
                        case 13:

                            break;
                        case 14:

                            break;
                        case 15:

                            break;
                        case 16:

                            break;
                        case 17:

                            break;
                        case 25:

                            break;
                        case 27:

                            break;
                        case 29:

                            break;
                    }
                }
                else
                {
                    output.Text = $"Алгоритм {algorithm.algorithm_number} не обрабатывает числа";
                }
            }
        }
        public experience()
        {
            InitializeComponent();
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Check_input();
            if (e.Key == Key.Escape)
                ExperienceBack_Click(sender, e);
        }
        private void ExperienceBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }
        
    }
}
