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
        private static object[] arr = new object[5];  // тесты 
        private static bool[] result = new bool[5];  //  массив ответов пользователя приведённый в bool
        private static int now;  // поле, которое нужно сохранять
        private static string[] answer = new string[5];  // ответы пользователя 
        private static string[] save_str = new string[3];

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
            "умение", "тряпка", "сейчас", "сланец", "рудник", "регион", "рецепт", "романс", "пузырь", "острый", "наверх", "нектар", "мостик", "рубашка", "кастрюля", "тюльпан", "ромашка", "лошадь", "кенгуру", "стрекоза", "снегирь", "кузнечик", "помидор", "виноград", "автобус", "пароход", "скрепка", "скрипка", "схватка", "вставка", "награда", "напиток", "начисто", "надежда", "напротив", "напрокат", "учитель", "ученица", "девочка", "октябрь", "суббота", "картина", "рисунок", "капуста", "человек", "мальчик", "деревня", "воробей", "субъект", "подъезд"
        };
        /*
        отдельная генерация для:
        для 6 группы: 0 или 1, 2 или 3, 3 или 4, 0 или 1, 4 или 5
        для 9 группы: нормальные слова с одной или двумя парами двойных букв, в нормальных словах нет парных букв, нормальные слова с двумя или тремя парными буквами, намешать набор букв лёгкой сложности, намешать набор букв сложный
        для 14 группы: 2 или 6, 4 или 8, 6 или 10, 8 или 12, 10 или 14
        для 25 группы: 2-4, 3-5, 4-6, 5-7, 6-8. больше Е в чётных и больше О в нечётных
        */

        private static string[,] _6 = { 
            {"растение", "сирень", "липа", "вишня", "ложь", "коршун", "охра", "слова", "осознать", "оборвать" }, 
            {"длинные", "статус", "организм", "опаздывать", "долг", "отрасль", "осознанный", "остроумный", "обесточить", "сторона"}, 
            {"выражение", "полуоборот", "геолог", "домофон", "хорошо", "водоворот", "волосок", "водоотвод", "голосовой", "околоземной"}, 
            {"давление", "щелкунчик", "барственный", "шпилька", "клавиатура", "пожарный", "автограф", "школа" , "попытка", "воспитание"}, 
            {"направление", "фтороводород", "околозвуковой", "золотоволосый", "товарооборот", "основополагающий", "обороноспособный", "противоположного", "провозоспособный", "обороноспособность"} };

        private static string[,] _9 = {
            {"жужжание", "зооорганизация", "зооохрана", "колоссальный", "настоящая драма", "сессия в субботу"},
            {"энергетический", "минеральный", "стандартный", "восточный", "философский", "интересный"},
            {"масса металла", "тонна кораллов", "русский рассказ", "пассивный пассажир", "миллиард звёзд", "балл класса"},
            {"в любой группе", "ШщщшЩш щшЩш", "нетто равно", "уравнение", "хоккей в это время", "ваш балл"},
            {"кКкШкКк", "аяАЯая А я а Я яаЯаА", "ПппРРрр", "КкыыЫшШш", "ОооОочеЕень много", "ЖужжжужЖууужжжуУуужж" } };

        private static string[,] _14 = {
            {"яд", "юг", "её", "крот", "дома", "река", "корова", "модный", "письмо", "ваш рай"}, 
            {"утро", "день", "свет", "фигура", "цемент", "ювелир", "аптекарь", "маслёнок", "каменщик", "кафе коса" }, 
            {"жёлудь", "истина", "космос", "менеджер", "картошка", "лабиринт", "обвинитель", "карамелька", "повелитель", "автор ангел" }, 
            {"ландшафт", "забвение", "фигурист", "поворотный", "банан багаж", "автомодель", "великодушный", "грубый бамбук", "удостоверить", "атомы ананаса" }, 
            {"живописный", "разделение", "синий огонь", "гордое яблоко", "сырой рабочий", "человечество", "обмундирование", "цветной зоопарк", "медленный забег", "главенствовать" } };
        //для 25 группы: 2-4, 3-5, 4-6, 5-7, 6-8. больше Е в чётных и больше О в нечётных
        private static string[,] _25 = {
            {"её", "он", "зло", "ещё", "она", "зов", "тебе", "обод", "реже" },
            {"ого", "око", "окно", "линия", "пьеса", "желе", "горох", "добро", "угол"},
            {"видеть", "темнее", "левее", "голод", "голос", "беглец", "беседа", "ведьма", "волос" },
            {"ворот", "довод", "мороз", "перейти", "железо", "лепесток", "боковой", "дерево", "пелена" },
            {"советовать", "деловой", "обычный", "чернее", "говорить", "опасность", "остановить", "здорово", "мороженое"} };
        private static string Generation_string(int hard)
        {
            Random rnd = new Random();
            int alg = algorithm.algorithm_number;
            if(alg == 6)
            {
                switch (hard)
                {
                    case 0:
                        return _6[hard, rnd.Next(0, 10)];
                    case 1:
                        return _6[hard, rnd.Next(0, 10)];
                    case 2:
                        return _6[hard, rnd.Next(0, 10)];
                    case 3:
                        return _6[hard, rnd.Next(0, 10)];
                    case 4:
                        return _6[hard, rnd.Next(0, 10)];
                }
            }
            
            if (alg == 9)
            {
                int len_all = 6;  // количество элементов в 1 строке
                switch (hard)
                {
                    case 0:
                        return _9[hard, rnd.Next(0, len_all)];
                    case 1:
                        return _9[hard, rnd.Next(0, len_all)];
                    case 2:
                        return _9[hard, rnd.Next(0, len_all)];
                    case 3:
                        return _9[hard, rnd.Next(0, len_all)];
                    case 4:
                        return _9[hard, rnd.Next(0, len_all)];
                }
            }

            if (alg == 14)
            {
                int len_all = 10;  // количество элементов в 1 строке
                switch (hard)
                {
                    case 0:
                        return _14[hard, rnd.Next(0, len_all)];
                    case 1:
                        return _14[hard, rnd.Next(0, len_all)];
                    case 2:
                        return _14[hard, rnd.Next(0, len_all)];
                    case 3:
                        return _14[hard, rnd.Next(0, len_all)];
                    case 4:
                        return _14[hard, rnd.Next(0, len_all)];
                }
            }

            if (alg == 25)
            {
                int len_all = 9;  // количество элементов в 1 строке
                switch (hard)
                {
                    case 0:
                        return _25[hard, rnd.Next(0, len_all)];
                    case 1:
                        return _25[hard, rnd.Next(0, len_all)];
                    case 2:
                        return _25[hard, rnd.Next(0, len_all)];
                    case 3:
                        return _25[hard, rnd.Next(0, len_all)];
                    case 4:
                        return _25[hard, rnd.Next(0, len_all)];
                }
            }

            switch (hard)
            {
                case 0:
                    return _0[rnd.Next(0, 50)];
                case 1:
                    return _1[rnd.Next(0, 50)];
                case 2:
                    return _2[rnd.Next(0, 50)];
                case 3:
                    return _3[rnd.Next(0, 50)];
                case 4:
                    return _4[rnd.Next(0, 50)];
            }
            return "Error";
        }

        private static void Fill_string(ref object[] arr)  // тест заполняется строками
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Generation_string(i);
        }

        private static int Gen(int div, int from, int before)
        {
            Random rnd = new Random();
            int num;
            do
            {
                num = rnd.Next(from, before);
            }
            while (num % div != 0);
            return num;
        }
        private static void Fill_int(ref object[] arr)  // тест заполняется числами
        {
            Random rnd = new Random();
            int alg = algorithm.algorithm_number;
            if(alg != 10 && alg != 11 && alg != 12)
            {
                arr[0] = rnd.Next(6, 40);
                arr[1] = rnd.Next(100, 500);
                arr[2] = rnd.Next(1000, 8000);
                arr[3] = rnd.Next(12000, 25000);
                arr[4] = rnd.Next(30000, 50000);
            }
            else
            {
                if (alg == 10 || alg == 12)
                {
                    // генерировать чётные числа
                    arr[0] = Gen(2, 6, 40);
                    arr[1] = Gen(2, 100, 500);
                    arr[2] = Gen(2, 1000, 8000);
                    arr[3] = Gen(2, 12000, 25000);
                    arr[4] = Gen(2, 30000, 50000);
                }
                else
                {
                    arr[0] = Gen(3, 6, 40);
                    arr[1] = Gen(3, 100, 500);
                    arr[2] = Gen(3, 1000, 8000);
                    arr[3] = Gen(3, 12000, 25000);
                    arr[4] = Gen(3, 30000, 50000);
                }
            }
        }
        private void Initial_generation()  // начальная генерация экзамена
        {
            exam_on.Text = $"Экзамен по {algorithm.algorithm_number} алгоритму";
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
            number_of_test.Text = $"Тест {now + 1} из 5";
            test.Text = Convert(arr[0]);
        }

        private void Update_exam()  // подгрузка всей информации в экзамен, когда пользователь вернулся в него
        {
            now = MainWindow.copy_now;
            test.Text = Convert(arr[now]);
            input_exam.Text = answer[now];
            exam_on.Text = save_str[0];
            number_of_test.Text = save_str[1];
            info.Text = save_str[2];
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
            MainWindow.experience_work = false;  // опыты заблокированы, если начат экзамен
            if (MainWindow.first_in_exam)
            {
                Initial_generation();  // сгенерироват новый экзамен
                MainWindow.first_in_exam = false;
                
            }
            else
                Update_exam();  // вернулись в экзамен, который не закончили следовательно это надо подгрузить
        }

        private void Save_all_info() // сохранение всех строк в экзамене, для перезахода в экзамен
        {
            MainWindow.copy_now = now;
            save_str[0] = exam_on.Text;
            save_str[1] = number_of_test.Text;
            save_str[2] = info.Text;
        }

        private void ExamBack_Click(object sender, RoutedEventArgs e)  // вызод из экзамена в меню
        {
            Save_all_info();
            Unlock_exam();
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
            
        }
        private void Updating_fields(int now)  // обновление полей вывожа информации при нажатии кнопок
        {
            test.Text = Convert(arr[now]);
            input_exam.Text = answer[now];
            number_of_test.Text = $"Тест {now + 1} из 5";
        }

        private void Last_test(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lock_exam)
            {
                info.Text = "Экзамен завершён, начните новый";
                return;
            }
            info.Text = "";
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
            info.Text = "";
            Checking_the_input(now);
            if (now < 4)
                now++;
            Updating_fields(now);
        }

        private void Unlock_exam()
        {
            if(MainWindow.first_in_exam)
                MainWindow.lock_exam = false;
        }

        private void Make_solution(object sender, RoutedEventArgs e)  // нажали на кнопку завершить экзамен 
        {
            
            if (MainWindow.lock_exam)  // завершить экзамен можно только один раз, чтобы не было спама в дневник 
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
                if (answer[i] == "")
                    answer[i] = "[Нет ответа]";
            if(counter >= 3)
                for (int i = 0; i < 5; i++)
                    experience.all_text += $"{i + 1, 2}){arr[i], -20} {answer[i], -13} {((result[i]) ? "Правильно" : "Неверно")}\n";
            else
                for (int i = 0; i < 5; i++)
                    experience.all_text += $"{i + 1,2}){arr[i],-20} {answer[i],-13} [Неизвестно]\n";
            experience.all_text += '\n';
            MainWindow.counter_exp = 1;  // если осталиcь после экзамена в том же алгоритме, то счётчик начинается сначала
            MainWindow.last_str_in_dairy = "";
            MainWindow.lock_exam = true;  // нельзя изменять экзамен после изменения
            test.Text = "";
            input_exam.Text = "";  // обнулить поля после завершения
            MainWindow.first_in_exam = true;  // сгенерировать новый экзамен, когда его завершили
            MainWindow.experience_work = true;  // опыты разблокированы, если экзаммен закончен
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            Save_all_info();
            Unlock_exam();
            NavigationService.Navigate(new calculator());
        }

        private void input_exam_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                Next_test(sender, e);
            if (e.Key == Key.R)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    info.Text = "Ответ: ";
                    if (experience.Input_string(algorithm.algorithm_number))
                        info.Text += experience.Algorithm_with_string(test.Text);
                    else
                        info.Text += experience.Algorithm_with_number(int.Parse(test.Text));
                }
            }
        }

        private void New_exam(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lock_exam)
            {
                Initial_generation();  // сгенерироват новый экзамен
                MainWindow.first_in_exam = false;
                MainWindow.lock_exam = false; // разблокировать кнопки в экзамене
                input_exam.Text = "";  // очисть поле ввода ответа, так как его значение уже не важно
                
            }
            else
                info.Text = "Завершите этот экзамен";            
        }

        private void Go_to_algorihm(object sender, RoutedEventArgs e)
        {
            Save_all_info();
            Unlock_exam();
            NavigationService.Navigate(new algorithm());
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow.copy_now = now;
            Save_all_info();
        }

        private void table_click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.alfavit_is_open)
            {
                table tableWindow = new table();
                tableWindow.Show();
                MainWindow.alfavit_is_open = true;
            }

        }
    }

    
}
