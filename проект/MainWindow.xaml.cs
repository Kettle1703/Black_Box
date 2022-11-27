using System.Windows;
using System;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Controls;

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
        public static bool alfavit_is_open = false;  // открыто окно алфавита или нет? true - открыто, false - закрыто
        public static bool experience_work = true;  // опыты работают или нет? (блоктровка опытов, во время экзамена) true - опыты работают, false - опыты заблокированы
        public static bool information_is_open = false;  // окно информации открыто или нет?
        public static int chapter = 0; // в каком разделе мы сейчас находимся 
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new menu();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                MainPage.Content = new menu();
            //MessageBox.Show((e.Key).ToString() + "  " + MainWindow.chapter);
            //ModifierKeys combCtrSh = ModifierKeys.Control | ModifierKeys.Shift;
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    MainPage.Content = new algorithm();
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    MainPage.Content = new experience();
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    MainPage.Content = new exam();
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    MainPage.Content = new diary();
            }
            if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    MainPage.Content = new calculator();
            }
            if(e.Key == Key.Up && chapter == 4)
            {
                // в дневнике
                //MainPage.Content.ScrollViewer.LineUp();
            }
            
        }
    }
}
