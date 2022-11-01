using System;
using System.Data;
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
    
    public partial class calculator : Page
    {
        //private bool have_syntactic_mistake = false;  // поле хранящее информацию о начилии синтактической ошибки 

        private void Click_AC(object sender, RoutedEventArgs e)
        {
            input.Text = "";
            output.Text = "";
        }

        private void Click_C(object sender, RoutedEventArgs e)
        {
            int len = input.Text.Length;
            input.Text = input.Text.Remove(len - 1, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // метод обрабазывающий нажатие кнопок 
        {
            string symbol = (string)((Button)e.OriginalSource).Content;
            input.Text += symbol;
        }
        private static int Quantity_search(string str, char letter)  // метод, считающий количество вхождений переданного символа в строку
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == letter)
                    result++;
            return result;
        }
        private static bool Сorrect_brackets(string str)  // метод распознающий неправильную скобочную последовательность
        {
            int open = calculator.Quantity_search(str, '(');
            int close = calculator.Quantity_search(str, ')');
            if (open == close)
            {
                string input = "";
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == '(' || str[i] == ')')
                        input += str[i];
                bool flag = true;
                while (flag && input.Length != 0)
                {
                    if (input[0] == ')' || input[input.Length - 1] == '(')
                        flag = false;
                    for (int i = 0; i < (input.Length - 1); i++)
                        if (input[i] == '(' && input[i + 1] == ')')
                            input = input.Remove(i, 2);
                }
                if (input.Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private static bool Belong_doubtful(string str, int index, bool oper)
        {
            int n = str[index];
            if(oper)  // выбор 
            {
                if ((n == 37) || (n == 42) || (n == 43) || (n == 45) || (n == 47))
                    return true;  // это + - * / %
                else
                    return false;
            }
            else
            {
                if (n >= 1072 && n <= 1103 || n == 1105)
                    return true; // a - я, кроме буквы ё и ё на 1105 позичии
                else
                    return false;
            }
            
        }
        private static bool Valid_simbol(string str)
        {
            bool flag = true;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                int n = str[i];
                if ((n < 35) || (n == 36) || (37 < n && n < 40) || (n == 44) || (57 < n && n < 1072) || (n == 1104) || (n > 1105))
                    flag = false; // в строке только числа, символы и русские буквы
                /*
                if (i != (len - 1))
                {
                    if (str[i] == '#' && calculator.Belong_doubtful(str, (i + 1), true))
                        flag = false; // после # нельзя операторы
                    if (calculator.Belong_doubtful(str, i, true) && calculator.Belong_doubtful(str, (i + 1), true))
                        flag = false;  // после операторов нельзя операторы
                    if (calculator.Belong_doubtful(str, i, true) && calculator.Belong_doubtful(str, (i + 1), false))
                        flag = false;  // после операторов нельзя буквы
                    if (str[i] == '#' && str[i + 1] == '#')
                        flag = false;  // после # нельзя #
                    if (calculator.Belong_doubtful(str, i, false) && calculator.Belong_doubtful(str, (i + 1), false))
                        flag = false; ;  // после букв нельзя буквы
                    if (calculator.Belong_doubtful(str, i, false) && str[i + 1] == '#')
                        flag = false; ;  // после букв нельзя #
                    // обработать граничные состояния операторы не должны быть в начале или в конце строки
                    // проще сначало изменить все # с буквами на числа а потом делать эту фигню
                }
                */
               
            }
            return flag;
        }
        
        private static string Letter_numbers(string str)
        {
            string result = "";
            int len = str.Length;
            int i = 0;
            for (; i < len; i++)
            {
                if (i != (len - 1) && str[i] == '#' && Belong_doubtful(str, i + 1, false))
                {
                    int number = str[i + 1];
                    if(number >= 1072 && 1077 >= number)    
                        number -= 1071;
                    if (number == 1105)
                        number = 7;
                    if (number > 1077 && number <= 1103)
                        number -= 1070;
                    result += number.ToString();
                    i += 1;
                }
                else
                    result += str[i];
            }
            return result;
        } 
        // написать остальные функции проверки по плану
        // написать функцию каскадной проверки вызывающая, написанные методы 
        
        

        private static bool General_inspection(string str)
        {
            
            if (!Valid_simbol(str))
                return false;
            if (!Сorrect_brackets(str))
                return false;

            return true;
        }
        private void Click_equality(object sender, RoutedEventArgs e)
        {
            if (calculator.General_inspection(input.Text))
            {
                input.Text = input.Text.ToLower();  // все большие буквы становяться маленькими
                input.Text = calculator.Letter_numbers(input.Text);
                string value = new DataTable().Compute(input.Text, null).ToString();
                output.Text = value;
            }
            else
                output.Text = "Синтактическая ошибка";
        }
        
        public calculator()
        {
            InitializeComponent();
           
            
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            

            label.Content = e.Key.ToString();
            
            if (e.Key == Key.Enter)
            {
                Click_equality(sender, e);
            }
            if(e.Key == Key.Escape)
            {
                CalculatorBack_Click(sender, e);
            }
            
        }

        private void CalculatorBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }

        private void CalculatorExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new exam());
        }
    }
}