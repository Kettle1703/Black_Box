using System;
using System.Data;
using System.Collections;
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

        private static bool Brackets_empty(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] == '(' && str[i + 1] == ')')
                    return true;
            return false;
        }

        private static bool Operator(object str) // это оператор ?
        {
            if (str is char result)
            {
                int n = result;
                if ((n == 37) || (n == 42) || (n == 43) || (n == 45) || (n == 47))
                    return true;  // это + - * / %
                else
                    return false;
            }
            else
                return false;
        }

        private static bool It_number(object str, bool left)  // это число ?
        {
            if (str is string)
                return true;
            else {
                if (str is char letter)
                {
                    if(left)
                        if (Char.IsLetter(letter) || letter == ')')
                            return true;
                        else
                            return false;
                    else
                        if (Char.IsLetter(letter) || letter == '(')
                            return true;
                        else
                            return false;
                }
                else
                    return false;
            }
        }
        private static bool Valid_simbol(string str, bool first)  // в строке все символы допустимые ?
        {
            if (first)  
            {
                for (int i = 0; i < str.Length; i++)
                {
                    int n = str[i];
                    if ((n < 35) || (n == 36) || (37 < n && n < 40) || (n == 44) || (n == 46) || (57 < n && n < 1072) || (n == 1104) || (n > 1105))
                        return false; // в строке только числа, символы и русские буквы
                }
                return true;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    int n = str[i];
                    if ((n == 35) || (n >= 1072 && n <= 1103) || (n == 1105))
                        return false;  // не должно быть букв и #
                }
                return true;
            }
        }
        
        private static string Letter_numbers(string str)  // в строке все #[буква] заменяются на порядковый номер буквы
        {
            string result = "";
            int len = str.Length;
            int i = 0;
            for (; i < len; i++)
            {
                if (i != (len - 1) && str[i] == '#' && Char.IsLetter(str[i + 1]))
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
        
        private static bool Сhecking_operations(string str)  // метод проверяющий возможность посчитать все операторы
        {
            ArrayList arr = new ArrayList();
            string number = "";
            for (int i = 0; i < str.Length; i++)
                if (Char.IsDigit(str[i]))
                    number += str[i];
                else
                    if (number != "")
                {
                    arr.Add(number);
                    number = "";
                    arr.Add(str[i]);
                }
                else
                    arr.Add(str[i]);
            if (number != "")
                arr.Add(number);
            int len = arr.Count;
            if (Operator(arr[0]) || Operator(arr[len - 1]))
                return false;  // оператор в начале или в конце строки
            if(len >= 3)
            {
                for (int i = 1; i <= len - 2; i++)
                    if (Operator(arr[i]))
                        if (!It_number(arr[i - 1], true) || !It_number(arr[i + 1], false))
                            return false;  // слева и справо от каждого оператора ложны быть числа или определённая скобка
            }
            return true;
        }

        private static bool Ban_operation(string str, int index)
        {
            if (str[index + 1] == '0')
                return true;
            else
            {
                if (str[index + 1] == '(')
                {
                    int counter = 1;
                    string warning = "(";
                    for (int i = index + 2; i < str.Length; i++)
                    {
                        if (str[i] == '(')
                            counter++;
                        if (str[i] == ')')
                            counter--;
                        warning += str[i];
                        if (counter == 0)
                        {
                            string value = new DataTable().Compute(warning, null).ToString();
                            if (value != "0")
                                return false;
                            else
                                return true;
                        }
                    }
                }
                else
                    return false;
                
            }
            return false;
        }
        
        private static bool General_inspection(ref string str, ref bool division_by_zero)
        {
            if (str == "")
                return false;  // если строка пустая
            if (!Valid_simbol(str, true))
                return false;  
            if (!Сorrect_brackets(str))
                return false;
            if (Brackets_empty(str))
                return false;
            str = str.ToLower();  // все большие буквы становяться маленькими
            str = Letter_numbers(str);
            if (!Valid_simbol(str, false))
                return false;
            if (!Сhecking_operations(str))
                return false;
            // если дошли до этого места, то строка полностью чиста и корректа, но до сих пор можно поделить на ноль или взять остаток от деления на ноль
            for (int i = 1; i < str.Length - 1; i++)
                if (str[i] == '/' || str[i] == '%')
                    if (Ban_operation(str, i))
                    {
                        division_by_zero = true;
                        return false;
                    }
            return true;
        }
        private void Click_equality(object sender, RoutedEventArgs e)
        {
            bool division_by_zero = false;
            string after = input.Text;
            if (General_inspection(ref after, ref division_by_zero))
            {
                input.Text = after;
                string value = new DataTable().Compute(input.Text, null).ToString();
                float result = float.Parse(value);
                output.Text = ((int)result).ToString();  // деление нацело
                
            }
            else
                if(division_by_zero)
                    output.Text = "Деление на ноль";
                else
                    output.Text = "Синтактическая ошибка";
        }
        
        public calculator()
        {
            InitializeComponent();
           
            
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            

            //label.Content = e.Key.ToString();
            
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