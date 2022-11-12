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
            if (str is string res)
            {
                if (res.Length > 1)
                {
                    if (res[0] == '0')
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            else {
                if (str is char letter)
                {
                    if(left)
                        if (letter == ')')
                            return true;
                        else
                            return false;
                    else
                        if (letter == '(')
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
                    if ((n < 35) || (n == 36) || (37 < n && n < 40) || (n == 44) || (n == 46) || (57 < n && n < 1025) || (1025 < n && n < 1040) || (n == 1104) || (n > 1105))
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

        private static bool Ban_operation(string str, int index)  // делим на ноль или нет ?
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

        private static int Find_bracket(string str, int index, bool before)  // поиск скобки того же уровня слева или справо от вхождения
        {
            if (before)
            {
                int res = 1;
                for (int i = index; i >= 0; i--)
                {
                    if (str[i] == ')')
                        res++;
                    if (str[i] == '(')
                        res--;
                    if (res == 0)
                        return i;
                }
            }
            else
            {
                int res = 1;
                for (int i = index; i < str.Length; i++)
                {
                    if (str[i] == '(')
                        res++;
                    if (str[i] == ')')
                        res--;
                    if (res == 0)
                        return i;
                }
            }
            return -1;
        }

        private static int Find_number(string str, int index, bool before)  // поиск начала или конца числа
        {
            int len = str.Length;
            if (before)
            {
                for (int i = index; i >= 0; i--)
                    if (!char.IsDigit(str[i]))
                        return i + 1;
                return 0;
            }
            else
            {
                for (int i = index; i < len; i++)
                    if (!char.IsDigit(str[i]))
                        return i - 1;
                return len - 1;
            }
        }

        private static string Substring_selection(string str, int index)  // выделение подстроки из str в index передаётся индекс деления или умножения
        {
            string result = "";
            int start;
            if (str[index - 1] == ')')
                start = Find_bracket(str, index - 2, true);
            else
                start = Find_number(str, index - 1, true);
            int end;
            if (str[index + 1] == '(')
                end = Find_bracket(str, index + 2, false);
            else
                end = Find_number(str, index + 1, false);

            for (int j = start; j <= end; j++)
                result += str[j];
            return result;
        }

        public static string Computing(string input, bool division)  // считает выражение в строке
        {
            string value = new DataTable().Compute(input, null).ToString();
            if (division)
            {
                float helper = float.Parse(value);
                return ((int)helper).ToString();  // деление нацело, то есть отбрасывание десятичной части
            }
            else
                return value;
        }

        public static void Multiplication_and_division(ref string str)  // отдельно считаются и заносятся в эту эе строку операции умножения и деления
        {
            int i_1 = str.IndexOf('*');
            int i_2 = str.IndexOf('/');
            while (i_1 != -1 || i_2 != -1)  // пока есть умножение или деление
            {
                if (i_1 == -1 && i_2 != -1) // в строке только операции деления
                {
                    string calc = Substring_selection(str, i_2);
                    str = str.Replace(calc, Computing(calc, true));
                }

                if (i_1 != -1 && i_2 == -1)  // в строке остались только умножения
                {
                    string calc = Substring_selection(str, i_1);
                    str = str.Replace(calc, Computing(calc, false));
                }

                if (i_1 != -1 && i_2 != -1)  // выбираем операцию, которая идёт раньше
                {
                    int index_before;
                    bool oper;
                    if (i_1 < i_2)
                    {
                        index_before = i_1;
                        oper = false;
                    }
                    else
                    {
                        index_before = i_2;
                        oper = true;
                    }
                    string calc = Substring_selection(str, index_before);
                    str = str.Replace(calc, Computing(calc, oper));
                }
                i_1 = str.IndexOf('*');
                i_2 = str.IndexOf('/');
            }
        }

        private static bool General_inspection(ref string str, ref bool division_by_zero)  // общая проверка поступившей строки
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
            Multiplication_and_division(ref str);  // все деления нацело
            return true;
        }
        private void Click_equality(object sender, RoutedEventArgs e)
        {
            bool division_by_zero = false;
            string after = input.Text;
            if (General_inspection(ref after, ref division_by_zero))
                try 
                {
                    output.Text = new DataTable().Compute(after, null).ToString();
                }
                catch (Exception)
                {
                    output.Text = "Синтактическая ошибка";  // отлавливание оставшихся ошибок
                }
            else
                if (division_by_zero)
                output.Text = "Деление на ноль";
            else
                output.Text = "Синтактическая ошибка";
        }

        public void Update_calculator()
        {
            input.Text = MainWindow.save_input_in_calc;
            output.Text = MainWindow.save_output_in_calc;
        }

        public calculator()
        {
            InitializeComponent();
            Update_calculator();
            
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
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
            MainWindow.save_input_in_calc = input.Text;
            MainWindow.save_output_in_calc = output.Text;
            NavigationService.Navigate(new menu());
        }

        private void CalculatorExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new exam());
        }
    }
}