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
using System.Text;

namespace проект
{
    public partial class experience : Page
    {
        public static string all_text;
        public static bool Is_Russian_Letter(char letter)  // метод определяющий русская буква или нет
        {
            if (char.IsLetter(letter))
            {
                string helper = letter.ToString();
                helper = helper.ToLower();
                int n = (helper[0]);
                if ((n >= 1072 && n <= 1103) || n == 1105)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private static bool Valid_str(string str)  // строка может содержать только русские буквы и пробелы
        {
            int counter_space = 0;
            foreach (char i in str)
            {
                if (!Is_Russian_Letter(i) && i != ' ')
                    return false;
                if(i == ' ') 
                    counter_space++;
            }
            if(counter_space == str.Length)  // не может быть строка только из пробелов
                return false;                
            return true;
        }
        public static int _1(int n, int N)
        {
            N = n + 1;
            return N;
        }
        public static int _2(int n, int N)
        {
            N = n * 2;
            return N;
        }
        public static int _3(int n, int N)
        {
            N = n * 2 + 1;
            return N;
        }
        public static int _4(int n, int N)
        {
            N = n * 2 - 1;
            return N;
        }
        public static string _5(string s)
        {
            if (Valid_str(s))
            {
                int N = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (Is_Russian_Letter(s[i]))
                        N++;
                }
                return N.ToString();
            }
            else
                return "Не могу";
        }
        public static string _6(string s)
        {
            if (Valid_str(s))
            {
                int N = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'О' || s[i] == 'о')
                        N++;
                }
                return N.ToString();
            }
            else
                return "Не могу";
        }
        public static int _7(int n, int N)
        {
            N = n * 4;
            return N;
        }
        public static int _8(int n, int N)
        {
            N = n * 4 - 1;
            return N;
        }
        public static string _9(string s)
        {
            if (Valid_str(s))
            {
                int N = 0;
                for (int i = 0; i < s.Length - 1;)
                {
                    if (i < 0)
                        i = 0;
                    if (s.Length == 1)
                        return N.ToString();
                    else
                    {
                        if (s[i] == s[i + 1] && Is_Russian_Letter(s[i]))
                        {
                            N++;
                            s = s.Remove(i, 2);
                        }
                        else
                            i++;
                    }
                }
                return N.ToString();
            }
            else
                return "Не могу";
        }
        public static string _10(int n)
        {
            if (n % 2 == 0)
                return (n / 2).ToString();
            else
                return "Не могу";
        }
        public static string _11(int n)
        {
            if (n % 3 == 0)
                return (n / 3).ToString();
            else
                return "Не могу";
        }
        public static string _12(int n)
        {
            if (n % 2 == 0)
                return (n / 2 - 1).ToString();
            else
                return "Не могу";
        }
        public static string _13(string s, string S)
        {
            if (Valid_str(s))
            {
                int i;
                StringBuilder Text = new StringBuilder(s);
                for (i = 'я'; i >= 'a'; i--)
                {
                    if (i == 'е')
                        Text = Text.Replace((char)i, '/');
                    if (i == 'я')
                        Text = Text.Replace((char)i, '_');
                    Text = Text.Replace((char)i, (char)(i + 1));
                }
                Text = Text.Replace('ё', '-');
                for (i = 0; i < Text.Length; i++)
                {
                    if (Text[i] == '/')
                        Text.Replace(Text[i], 'ё');
                    if (Text[i] == '-')
                        Text.Replace(Text[i], 'ж');
                    if (Text[i] == '_')
                        Text.Replace(Text[i], 'а');
                }
                S = Convert.ToString(Text);
                return S;
            }
            else
                return "Не могу";
        }
        public static string _14(string s)
        {
            if (Valid_str(s))
            {
                int len = int.Parse(_5(s));
                if (len % 2 == 0)
                    return (len / 2).ToString();
                else
                    return "Не могу";
            }
            else
                return "Не могу";
            
        }
        public static string _15(string s)
        {
            if (Valid_str(s))
            {
                char str = ' ';
                foreach (char ch in s)
                {
                    if (Is_Russian_Letter(ch))
                        if (ch > str && ch != 'ё' && str != 'ё')
                            str = ch;
                        else
                        {
                            if (ch == 'ё')
                            {
                                if ((int)str <= 1077)
                                    str = ch;
                            }
                            if (str == 'ё')
                            {
                                if ((int)ch >= 1078)
                                    str = ch;
                            }
                        }
                }
                return str.ToString();
            }
            else
                return "Не могу";
        }
        public static string _16(string s)
        {
            if (Valid_str(s))
            {
                char str = 'я';
                foreach (char ch in s)
                {
                    if (ch < str && ch != 'ё' && str != 'ё')
                        str = ch;
                    else
                    {
                        if (ch == 'ё')
                        {
                            if ((int)str >= 1078)
                                str = ch;
                        }
                        if (str == 'ё')
                        {
                            if ((int)ch <= 1077)
                                str = ch;
                        }
                    }

                }
                return str.ToString();
            }
            else
                return "Не могу";
        }

        private static bool Uniq(string s)  // в строке должны быть уникальные как минимум два уникальных символа
        {
            char first = ' ';
            foreach(char ch in s)
            {
                if(first == ' ' && Is_Russian_Letter(ch))
                    first = ch;
                else
                {
                    if (first != ' ' && Is_Russian_Letter(ch) && ch != first)
                        return true;
                }
            }
            return false;
        }
        public static string _17(string s)
        {
            if (Uniq(s))
            {
                if (Valid_str(s))  // возможно это лишняя проверка
                    return _16(s) + _15(s);  
                else
                    return "Не могу";
            }
            else
                return "Не могу";
        }
        public static int _18(int n, int N)
        {
            N = 0;
            n = Math.Abs(n);
            while (n > 9)
            {
                n /= 10;
                N++;
            }
            N++;
            return N;
        }
        public static int _19(int n, int N)
        {
            N = 0;
            n = Math.Abs(n);
            while (n > 9)
            {
                N = N + n % 10;
                n /= 10;
            }
            N += n;
            return N;
        }
        public static int _20(int n, int N)
        {
            n = Math.Abs(n);
            int min = 9;
            int max = 0;
            while (n > 9)
            {
                if (n % 10 < min)
                    min = n % 10;
                if (n % 10 > max)
                    max = n % 10;
                n /= 10;
            }
            if (n < min)
                min = n;
            if (n > max)
                max = n;
            N = max - min;
            return N;
        }
        static int _21(int n, int N)
        {
            n = Math.Abs(n);  
            int min = 9;
            int max = 0;
            while (n > 9)
            {
                if (n % 10 < min)
                    min = n % 10;
                if (n % 10 > max)
                    max = n % 10;
                n /= 10;
            }
            if (n < min)
                min = n;
            if (n > max)
                max = n;
            N = max + min;
            return N;
        }
        static int _22(int n, int N)
        {
            N = n;
            if (n == 0)
                return 0;
            while (N % 2 == 0 && N != 1)
                N = N / 2;
            return N;
        }
        static int _23(int n, int N)
        {
            if (n % 2 == 0)
                N = n / 2;
            else
                N = n * 2;
            return N;
        }
        static int _24(int n, int N)
        {
            string s;
            string str = "";
            s = n.ToString();
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 48)
                    str = $"{str}" + $"{9}";
                else
                {
                    str = $"{str}" + $"{(int)s[i] - 49}";
                }
            }
            N = Convert.ToInt32(str);
            return N;
        }
        static string _25(string s)
        {
            if (Valid_str(s))
            {
                int kol = 0, kolEO = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (Is_Russian_Letter(s[i]))
                        kol++;
                }
                if (kol % 2 == 0)
                {
                    foreach (char ch in s)
                    {
                        if (ch == 'Е' || ch == 'е')
                            kolEO++;
                    }
                }
                else
                    foreach (char ch in s)
                    {
                        if (ch == 'О' || ch == 'о')
                            kolEO++;
                    }
                return kolEO.ToString();
            }
            else
                return "Не могу";
        }
        static string _26(string s)
        {
            if (Valid_str(s))
            {
                int kol = 0;
                for (int i = 0; i < s.Length; i++)
                {

                    if ((int)s[i] == 1025 || (int)s[i] == 1105)
                        kol += 7;
                    else
                    {
                        if ((int)s[i] < 1072 && (int)s[i] > 1045)
                            kol += (int)s[i] - 1038;
                        if ((int)s[i] <= 1045)
                            kol += (int)s[i] - 1039;
                        if ((int)s[i] > 1071 && (int)s[i] <= 1077)
                            kol += ((int)s[i] - 1071);
                        if ((int)s[i] > 1077)
                            kol += ((int)s[i] - 1070);
                    }

                }
                return kol.ToString();
            }
            else
                return "Не могу";
        }
        static string _27(string s)
        {
            if (Valid_str(s))
            {
                return (int.Parse(_26(s)) * 2).ToString();
            }
            else
                return "Не могу";
        }
        public static int _28(int number)
        {
            return number % 3;
        }

        public static string _29(string str)
        {
            if (Valid_str(str))
            {
                var vowelArray = str.Where(c => "аоуэыяёюеиАОУЭЫЯЁЮЕИ".Contains(c)).ToArray();
                return vowelArray.Length.ToString();
            }
            else
                return "Не могу";
        }


        public static bool Input_string(int n)  // у алгоритма с этим номером на вход строка ? 
        {
            if(n == 5 || n == 6 || n == 9 || (n >= 13 && n <= 17) || n == 25 || n == 26 || n == 27 || n == 29)
                return true;
            else 
                return false;
        }

        public static string Algorithm_with_number(int number)  // вызвать алгоритм, если он принимает число
        {
            switch (algorithm.algorithm_number)
            {
                case 1:
                    return _1(number, 0).ToString();
                case 2:
                    return _2(number, 0).ToString();
                case 3:
                    return _3(number, 0).ToString();
                case 4:
                    return _4(number, 0).ToString();
                case 7:
                    return _7(number, 0).ToString();
                case 8:
                    return _8(number, 0).ToString();
                case 10:
                    return _10(number);
                case 11:
                    return _11(number);
                case 12:
                    return _12(number);
                case 18:
                    return _18(number, 0).ToString();
                case 19:
                    return _19(number, 0).ToString();
                case 20:
                    return _20(number, 0).ToString();
                case 21:
                    return _21(number, 0).ToString();
                case 22:
                    return _22(number, 0).ToString();
                case 23:
                    return _23(number, 0).ToString();
                case 24:
                    return _24(number, 0).ToString();
                case 28:
                    return _28(number).ToString();
            }
            return "Error";
        }

        public static string Algorithm_with_string(string str)  // вызвать алгоритм, если он принимает строку
        {
            str = str.ToLower();
            switch (algorithm.algorithm_number)
            {
                case 5:
                    return _5(str);
                case 6:
                    return _6(str);
                case 9:
                    return _9(str);
                case 13:
                    return _13(str, "");
                case 14:
                    return _14(str);
                case 15:
                    return _15(str);
                case 16:
                    return _16(str);
                case 17:
                    return _17(str);
                case 25:
                    return _25(str);
                case 26:
                    return _26(str);
                case 27:
                    return _27(str);
                case 29:
                    return _29(str);
            }
            return "Error";
        }

        private void Check_input()  // строка пользователя преобрахуется алгоритмами + добавление опыта в дневник
        {
            if(input.Text.Length >= 21)  // чтобы в дневнике не ломались столбики
            {
                output.Text = "Слишком длинный ввод";
                return;
            }
            int number;
            bool flag = int.TryParse(input.Text, out number);
            if(!Input_string(algorithm.algorithm_number))
            {
                // пользователь ввёл число и может использовать алгоритмы: 1. 2. 3. 4. 7. 8. 10. 11. 12. с 18 по 24. 28
                if(flag)
                {
                    input.Text = number.ToString();
                    if (number <= 536870900 && number >= -536870900)
                        output.Text = Algorithm_with_number(number);  
                    else
                        output.Text = "Слишком большое число";
                }
                else
                {
                    output.Text = "Не могу";
                }
            }
            else
            {
                // пользователь ввёл строку и может использовать алгоритмы: 5. 6. 9. c 13 по 17. 25. 26. 27. 29
                output.Text = Algorithm_with_string(input.Text);
                
            }

            if (MainWindow.counter_exp == 1)  // добавление опыта в дневник 
            {
                all_text += $"Опыты алгоритма #{algorithm.algorithm_number}\n";
            }
            string new_string = $"{input.Text,-20}{output.Text}\n";
            if (new_string != MainWindow.last_str_in_dairy)
            {
                MainWindow.last_str_in_dairy = new_string;
                all_text += $"{MainWindow.counter_exp++,2}){input.Text,-20} {output.Text}\n";
            }
        }
        public experience()
        {
            InitializeComponent();
            if(algorithm.algorithm_number == 9)  // подгрузка подсказки, у определённых алгоритмов
            {
                input.Text = "соответственно";
                output.Text = "2";
            }
            if(algorithm.algorithm_number == 25)
            {
                input.Text = "длинношеее";
                output.Text = "3";
            }
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)  // обработка поднятия клавиши
        {
            if (e.Key == Key.Enter && MainWindow.experience_work)
            {
                Check_input();
            }
            if (e.Key == Key.Enter && !MainWindow.experience_work)
            {
                output.Text = "[Начат экзамен]";
            }
            if (e.Key == Key.Escape)
                ExperienceBack_Click(sender, e);
        }
        private void ExperienceBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }
        private void ExperienceExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }

        private void Go_to_exam(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new exam());
        }

        private void Go_to_diary(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new diary());
        }

        private void table_click(object sender, RoutedEventArgs e)
        {
            if(!MainWindow.alfavit_is_open)
            {
                table tableWindow = new table();
                tableWindow.Show();
                MainWindow.alfavit_is_open = true;
            }
            
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            input.Text = "";
            output.Text = "";
        }
    }
}
