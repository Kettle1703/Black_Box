using System.Windows;
using System;

/*
1) вопрос об оптимальности программы с точки зрения программирования ведь не стоит ? Не лагает, но просто
2) есть алгоритмы с делением 10, 11, 12, 14, 23 опыты выдвдут неделую часть, это нормально ? 
3) что генерировать в экзамене для 10, 11, 12, 14 и 23 алгоритма (ответы могут быть не целыми) ?
4) у опытов может переполниться int и опыты вообще не обрабатывают float
5) если екзамен не пройден, то генерировать новый или не менять его ? 
*/

namespace проект
{
    public partial class MainWindow : Window
    {
        public static string save_input_in_calc;
        public static string save_output_in_calc;
        public static bool first_change_algorithm = true;
        public static string save_ouput_algoritm = "";
        public static int counter_exp = 1;  // номер опыта в опытах (для дневника)
        public static bool first_in_exam = true;  // первый раз зашли в экзамен. true - сгенерировать новый экзамен, false - загрузить начатый экзамен

        //public static object[] copy_arr = new object[5];  // копии полей экзамена
        //public static bool[] copy_result = new bool[5];
        public static int copy_now;  // видимо, это единственная нужная копия для экзамена, остальные можно удалить
        //public static string[] copy_answer = new string[5];
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new menu();
        }
    }
}
