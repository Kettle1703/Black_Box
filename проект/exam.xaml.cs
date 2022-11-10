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
    public partial class exam : Page
    {
        private static object[] arr;
        private static bool[] result;
        private static int now;
        private static string[] answer;
        private static string[] quantifier =
        {
            "все", "некоторые", "многие", "определённые", "всякие", "редкие", "часто", "эти", "те же", "вот эти", "какие"
        };
        private static string[] subject =
        {
            "машины", "люди", "звери", "животные", "растения", "программы", "совы", "фигуры", "дети", "студенты", "ученики", "круги"
        };
        private static string[] bundle =
        {
            "являются", "получаются", "становятся", "не являются", "не получаются", "не становятся", "будут", "не будут"
        };
        private static string[] adjectives =
        {
            "хорошими", "плохими", "работающими", "неработающими", "класными", "привлекательными", "яркими", "солнечными", "эффективными", "увлекательными", "растущими",
        };

        private static int len_1 = quantifier.Length - 1;
        private static int len_2 = subject.Length - 1;
        private static int len_3 = bundle.Length - 1;
        private static int len_4 = adjectives.Length - 1;

        private void Initial_generation()  // начальная генерация 
        {
            arr = new object[5];
            if (experience.Input_string(algorithm.algorithm_number))
                Fill_string(ref arr);
            else
                Fill_int(ref arr);
            result = new bool[5];
            answer = new string[5];
            for (int i = 0; i < 5; i++)
            {
                result[i] = false;
                answer[i] = "";
            }
            now = 0;
            test.Text = Convert(arr[0]);
        }

        private static string Generation_string()  // 1, 2, 3,   1-2, 3-4
        {
            Random rand = new Random();
            string res = "";
            string str_1 = quantifier[rand.Next(0, len_1)];
            string str_2 = subject[rand.Next(0, len_2)];
            string str_3 = bundle[rand.Next(0, len_3)];
            int role = rand.Next(1, 12);
            if (role % 2 == 1)
            {
                role = rand.Next(1, 12);
                switch (role % 3)
                {
                    case 0:
                        res = str_1;
                        break;
                    case 1:
                        res = str_2;
                        break;
                    case 2:
                        res = str_3;
                        break;
                }
            }
            else
            {
                role = rand.Next(1, 12);
                switch (role % 2)
                {
                    case 0:
                        res = str_1 + " " + str_2;
                        break;
                    case 1:
                        res = str_3 + " " + adjectives[rand.Next(0, len_4)];
                        break;
                }
            }
            return res;
        }

        private static void Fill_string(ref object[] arr)  // тест заполняется строками
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Generation_string();
        }
        private static void Fill_int(ref object[] arr)  // тест заполняется числами
        {
            Random rnd = new Random();
            arr[0] = rnd.Next(0, 40);
            arr[1] = rnd.Next(100, 400);
            arr[2] = rnd.Next(401, 9999);
            arr[3] = rnd.Next(15000, 25000);
            arr[4] = rnd.Next(50001, 100000);
        }

        public static string Convert(object res) // принимает object переделывает его в string
        {                                       // для object работает ToString(), но она генерит предупреждение
            if (res is string str)
                return str;
            else
                if (res is int number)
                return number.ToString();
            else
                return "Error";
        }
        public exam()
        {
            InitializeComponent();
            Initial_generation();
        }


        private void ExamBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new menu());
        }

        private void Checking_the_input(int now)
        {
            if (experience.Input_string(algorithm.algorithm_number))
            {
                // алгоритм на вход требует строку
                string true_result = experience.Algorithm_with_string(test.Text);
                if (true_result == input_exam.Text)
                    result[now] = true;
                else 
                    result[now] = false;
                answer[now] = input_exam.Text;
            }
            else
            {
                string true_result = experience.Algorithm_with_number(int.Parse(test.Text));
                if (true_result == input_exam.Text)
                    result[now] = true;
                else
                    result[now] = false;
                answer[now] = input_exam.Text;
            }
            
            info.Text = "";
            for (int i = 0; i < 5; i++)
            {
                if (result[i])
                    info.Text += "1 ";
                else
                    info.Text += "0 ";
            }
        }
        private void Updating_fields(int now)
        {
            test.Text = Convert(arr[now]);
            input_exam.Text = answer[now];

        }

        private void Last_test(object sender, RoutedEventArgs e)
        {
            Checking_the_input(now);
            if (now > 0)
                now--;
            Updating_fields(now);
        }

        private void Next_test(object sender, RoutedEventArgs e)
        {
            Checking_the_input(now);
            if (now < 4)
                now++;
            Updating_fields(now);
        }
    }

    
}
