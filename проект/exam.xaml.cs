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
        private static object[] arr = new object[5];  
        private static bool[] result = new bool[5];
        private static int now;  // поле, которое нужно сохранять
        private static string[] answer = new string[5];

        private static string[] _0 =
        {
            "сон", "дом", "рот", "том", "ток", "бак", "кит", "сыр", "кон", "бык", "пик", "рай", "да", "нет", "о", "лес", "яма", "як", "век", "я", "он", "мы", "они", "она", "ёж", "её", "его", "ил", "ум", "юг", "яд", "год", "мой", "два", "три", "мак", "душ", "бас", "луг", "фен", "имя", "мех", "око", "йог", "шаг", "фея", "оса", "юла", "уют", "вид"
        };
        private static string[] _1 =
        {
            "ритм", "стог", "куст", "стол", "стул", "мрак", "врач", "метр", "шкаф", "лист", "тигр", "ложь", "ночь", "волк", "град", "гром", "снег", "хлеб", "свет", "пар", "чай", "ключ", "сто", "кот", "фен", "шар", "муха", "ваза", "жар", "год", "щука", "чудо", "часы", "буря", "таз", "пояс", "труд", "конь", "небо", "волос", "кулон", "слово", "зло", "цирк", "пыль", "трюк", "стог", "цель", "семь", "гном"
        };
        private static string[] _2 =
        {
            "писк", "роль", "вода", "плечо", "станок", "стакан", "дворец", "мешок", "клоун", "пиджак", "пальто", "кофта", "вилка", "кружка", "зебра", "комар", "пчела", "осина", "груша", "банан", "яблоко", "поезд", "букет", "сапог", "пламя", "кабан", "лень", "печь", "слива", "полоса", "машина", "назад", "голос", "урок", "палка", "атака", "валун", "горка", "добро", "жираф", "жильё", "зефир", "загон", "крыша", "ковёр", "лампа", "кошка", "фильм", "ровно", "игрок"
        };
        private static string[] _3 =
        {
            "линия", "масло", "мойка", "обход", "окунь", "орган", "отель", "очный", "плита", "почта", "юрист", "эпоха", "аромат", "апрель", "алтарь", "выступ", "грусть", "долина", "ёлочка", "единый", "еловый", "юность", "эпилог", "щетина", "шахтёр", "шутник", "чудище", "ценить", "хлопья", "хищник", "фиаско", "фарфор", "футбол", "фермер", "хрюшка", "ураган", "пример", "гектар", "перила", "карниз", "педаль", "талант", "лагерь", "огород", "магазин", "малина", "костёр", "океан", "мебель", "яблоня"
        };
        private static string[] _4 =
        {
            "умение", "тряпка", "сейчас", "сланец", "рудник", "регион", "рецепт", "роман", "пузырь", "острый", "наверх", "нектар", "мостик", "рубашка", "кастрюля", "тюльпан", "ромашка", "лошадь", "кенгуру", "стрекоза", "снегирь", "кузнечик", "помидор", "виноград", "автобус", "пароход", "скрепка", "скрипка", "схватка", "вставка", "награда", "напиток", "начисто", "надежда", "напротив", "напрокат", "учитель", "ученица", "девочка", "октябрь", "суббота", "картина", "рисунок", "капуста", "человек", "мальчик", "деревня", "воробей", "субъект", "подъезд"
        };

        private static string Generation_string(int hard)
        {
            Random rnd = new Random();
            switch (hard)
            {
                case 0:
                    return _0[rnd.Next(0, 49)];
                case 1:
                    return _1[rnd.Next(0, 49)];
                case 2:
                    return _2[rnd.Next(0, 49)];
                case 3:
                    return _3[rnd.Next(0, 49)];
                case 4:
                    return _4[rnd.Next(0, 49)];
            }
            return "Error";
        }

        private static void Fill_string(ref object[] arr)  // тест заполняется строками
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Generation_string(i);
        }
        private static void Fill_int(ref object[] arr)  // тест заполняется числами
        {
            Random rnd = new Random();
            arr[0] = rnd.Next(6, 40);
            arr[1] = rnd.Next(100, 500);
            arr[2] = rnd.Next(1000, 8000);
            arr[3] = rnd.Next(12000, 25000);
            arr[4] = rnd.Next(30000, 50000);
        }
        private void Initial_generation()  // начальная генерация 
        {
            if (experience.Input_string(algorithm.algorithm_number))
                Fill_string(ref arr);
            else
                Fill_int(ref arr);
            for (int i = 0; i < 5; i++)
            {
                result[i] = false;
                answer[i] = "";
            }
            now = 0;
            test.Text = Convert(arr[0]);
        }

        private void Update_exam()
        {
            now = MainWindow.copy_now;
            test.Text = Convert(arr[now]);
            input_exam.Text = answer[now];
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
            if(MainWindow.first_in_exam)
            {
                Initial_generation();  // сгенерироват новый экзамен
                MainWindow.first_in_exam = false;
            }
            else
                Update_exam();  // вернулись в экзамен, который не закончили следовательно это надо подшрузить
        }


        private void ExamBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.copy_now = now;
            NavigationService.Navigate(new menu());
        }

        private void Checking_the_input(int now)  // проверка правильности ответа
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
                // алгоритм на вход требует число
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
        private void Updating_fields(int now)  // обновление полей вывожа информации при нажатии кнопок
        {
            test.Text = Convert(arr[now]);
            input_exam.Text = answer[now];

        }

        private void Last_test(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lock_exam)
            {
                info.Text = "Экзамен завершён, начните новый";
                return;
            }
            Checking_the_input(now);
            if (now > 0)
                now--;
            Updating_fields(now);
        }

        private void Next_test(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lock_exam)
            {
                info.Text = "Экзамен завершён, начните новый";
                return;
            }
            Checking_the_input(now);
            if (now < 4)
                now++;
            Updating_fields(now);
        }

        private void Make_solution(object sender, RoutedEventArgs e)  // нажали на кнопку завершить экзамен 
        {
            if (MainWindow.lock_exam)
            {
                info.Text = "Экзамен завершён, начните новый";
                return;
            }
            Checking_the_input(now);  // последний ввод проверить, если пользователь не нажал 
            int counter = 0; 
            for(int i = 0; i < 5; i++)
                if(result[i])
                    counter++;
            string conclusion;
            if (counter >= 3)
                conclusion = $"Экзамен по {algorithm.algorithm_number} алгоритму сдан";
            else
                conclusion = $"Экзамен по {algorithm.algorithm_number} алгоритму не сдан";
            info.Text = conclusion;
            MainWindow.first_in_exam = true;  // генерация нового экзамена
            experience.all_text += $"\n{conclusion}\n";
            for (int i = 0; i < 5; i++)
            {
                experience.all_text += $"{i + 1, 2}){arr[i], -15} {answer[i], -15} {((result[i]) ? "Правильно" : "Неверно")}\n";
            }
            experience.all_text += '\n';
            MainWindow.counter_exp = 1;  // если осталиь после экзамена в том же алгоритме, то счётчик начинается сначала
            MainWindow.last_str_in_dairy = "";
            MainWindow.lock_exam = true;
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.copy_now = now;
            NavigationService.Navigate(new calculator());
        }

        private void input_exam_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                Next_test(sender, e);
        }

        private void New_exam(object sender, RoutedEventArgs e)
        {
            Initial_generation();  // сгенерироват новый экзамен
            MainWindow.first_in_exam = false;
            MainWindow.lock_exam = false; // разблокировать кнопки в экзамене
            input_exam.Text = "";  // очисть поле ввода ответа, так как его значение уже не важно
        }

        private void Go_to_algorihm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new algorithm());
        }
    }

    
}
