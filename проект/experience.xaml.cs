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
        public static int _5(string s, int N)
        {
            N = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                    N++;
            }
            return N;
        }
        public static int _6(string s, int N)
        {
            N = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'О')
                    N++;
            }
            return N;
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
        public static int _9(string s, int N)
        {
            N = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s.Length == 1)
                    return 0;
                if (i == 0)
                {
                    if (s[i] == s[i + 1] && char.IsLetter(s[i]))
                        N++;
                }
                else
                if (s[i] == s[i + 1] && char.IsLetter(s[i]) || s[i] == s[i - 1] && char.IsLetter(s[i]))
                    N++;
            }
            return N;
        }
        public static double _10(double n, double N)
        {
            N = n / 2;
            return N;
        }
        public static double _11(double n, double N)
        {
            N = n / 3;
            return N;
        }
        public static double _12(double n, double N)
        {
            N = n / 2 - 1;
            return N;
        }
        public static string _13(string s, string S)
        {
            int i;
            StringBuilder Text = new StringBuilder(s);
            for (i = 'я'; i >= 'a'; i--)
            {
                if (i == 'я') Text = Text.Replace((char)i, '_');
                if (i == 'z') Text = Text.Replace((char)i, '-');
                Text = Text.Replace((char)i, (char)(i + 1));
            }
            for (i = 0; i < Text.Length; i++)
            {
                if (Text[i] == '_') Text.Replace(Text[i], 'а');
                if (Text[i] == '-') Text.Replace(Text[i], 'a');
            }
            S = Convert.ToString(Text);
            return S;
        }
        public static double _14(string s, double N)
        {
            N = s.Length / 2;
            return N;
        }
        public static char _15(string s, char S)
        {
            s = s.ToLower();  // строка "AA" становиться "аа" и с английскими так же работает
            char str = 'а';
            foreach (char ch in s)
            {
                if (ch > str)
                    str = ch;
            }
            S = str;
            return S;
        }
        public static char _16(string s, char S)
        {
            char str = 'я';
            foreach (char ch in s)
            {
                if (ch < str)
                    str = ch;
            }
            S = str;
            return S;
        }
        public static string _17(string s, string S)
        {
            char str1 = 'а';
            foreach (char ch in s)
            {
                if (ch > str1)
                    str1 = ch;
            }
            char str2 = 'я';
            foreach (char ch in s)
            {
                if (ch < str2)
                    str2 = ch;
            }
            S = $"{str2}" + $"{str1}";
            return S;
        }
        public static int _18(int n, int N)
        {
            N = 0;
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
            while (n % 2 == 0)
                N = n / 2;
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
        static string _24(int n, string str)
        {
            string s;
            str = "";
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
            return str;
        }
        static int _25(string s, int N)
        {
            int kol = 0, kolEO = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                    kol++;
            }
            if (kol % 2 == 0)
            {
                foreach (char ch in s)
                {
                    if (ch == 'Е')
                        kolEO++;
                }
            }
            else
                foreach (char ch in s)
                {
                    if (ch == 'О')
                        kolEO++;
                }
            N = kolEO;
            return N;
        }
        static int _26(string s, int N)
        {
            int kol = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
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
            }
            N = kol;
            return N;
        }
        static int _27(string s, int N)
        {
            int kol = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
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
            }
            N = kol * 2;
            return N;
        }
        public static int _28(int number)
        {
            return number % 3;
        }

        public static int _29(string str)
        {
            var vowelArray = str.Where(c => "aeiouyAEIOUYаоуэыяёюеиАОУЭЫЯЁЮЕИ".Contains(c)).ToArray();
            return vowelArray.Length;
        }

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
            if(!Input_string(algorithm.algorithm_number))
            {
                // пользователь ввёл число и может использовать алгоритмы: 1. 2. 3. 4. 7. 8. 10. 11. 12. с 18 по 24. 28
                if(flag)
                {
                    switch(algorithm.algorithm_number)
                    {
                        case 1:
                            output.Text = _1(number, 0).ToString();
                            break;
                        case 2:
                            output.Text = _2(number, 0).ToString();
                            break;
                        case 3:
                            output.Text = _3(number, 0).ToString();
                            break;
                        case 4:
                            output.Text = _4(number, 0).ToString();
                            break;
                        case 7:
                            output.Text = _7(number, 0).ToString();
                            break;
                        case 8:
                            output.Text = _8(number, 0).ToString();
                            break;
                        case 10:
                            output.Text = _10(number, 0).ToString();
                            break;
                        case 11:
                            output.Text = _11(number, 0).ToString();
                            break;
                        case 12:
                            output.Text = _12(number, 0).ToString();
                            break;
                        case 18:
                            output.Text = _18(number, 0).ToString();
                            break;
                        case 19:
                            output.Text = _19(number, 0).ToString();
                            break;
                        case 20:
                            output.Text = _20(number, 0).ToString();
                            break;
                        case 21:
                            output.Text = _21(number, 0).ToString();
                            break;
                        case 22:
                            output.Text = _22(number, 0).ToString();
                            break;
                        case 23:
                            output.Text = _23(number, 0).ToString();
                            break;
                        case 24:
                            output.Text = _24(number, "").ToString();
                            break;
                        case 28:
                            output.Text = _28(number).ToString();
                            break;
                    }
                }
                else
                {
                    output.Text = "Не могу";
                }
            }
            else
            {
                // пользователь ввёл строку и может использовать алгоритмы: 5. 6. 9. c 13 по 17. 25. 26. 27. 29
                switch (algorithm.algorithm_number)
                {
                    case 5:
                        output.Text = _5(input.Text, 0).ToString();
                        break;
                    case 6:
                        output.Text = _6(input.Text, 0).ToString();
                        break;
                    case 9:
                        output.Text = _9(input.Text, 0).ToString();
                        break;
                    case 13:
                        output.Text = _13(input.Text, "").ToString();
                        break;
                    case 14:
                        output.Text = _14(input.Text, 0).ToString();
                        break;
                    case 15:
                        output.Text = _15(input.Text, '0').ToString();
                        break;
                    case 16:
                        output.Text = _16(input.Text, '0').ToString();
                        break;
                    case 17:
                        output.Text = _17(input.Text, "").ToString();
                        break;
                    case 25:
                        output.Text = _25(input.Text, 0).ToString();
                        break;
                    case 26:
                        output.Text = _26(input.Text, 0).ToString();
                        break;
                    case 27:
                        output.Text = _27(input.Text, 0).ToString();
                        break;
                    case 29:
                        output.Text = _29(input.Text).ToString();
                        break;
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
            {
                Check_input();
                all_text += $"{input.Text} - {output.Text}\n";
            }
            if (e.Key == Key.Escape)
                ExperienceBack_Click(sender, e);
        }
        private void ExperienceBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }
        
    }
}
