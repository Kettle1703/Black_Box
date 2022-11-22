using System.Windows;
using System;

namespace проект
{
    public partial class MainWindow : Window
    {
        public static string save_input_in_calc;
        public static string save_output_in_calc;
        public static string save_ouput_algoritm = "";
        public static int counter_exp = 1;  // номер опыта в опытах (для дневника)
        public static bool first_in_exam = true;  // первый раз зашли в экзамен. true - сгенерировать новый экзамен, false - загрузить начатый экзамен
        public static int copy_now;  // видимо, это единственная нужная копия для экзамена, остальные можно удалить
        public static string last_str_in_dairy = "";  // последняя строка в дневнике (чтобы не спами в дневник одинаковой строкой)
        public static bool lock_exam = false;  // заблокировать действия в экзамене ? true - заблокировать кнопки Следующий и Предыдуший тест и саму Кнопку Завершить, false - все кнопки в Экзаменен работают
        public static bool alfavit_is_open = false;
        public static bool experience_work = true;
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new menu();
        }
    }
}
