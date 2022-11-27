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
using System.Windows.Shapes;

namespace проект
{
    
    public partial class information : Window
    {
        public information()
        {
            InitializeComponent();
            inform.Text = "Полезная информация:\n\n" +
                "Общие горячие клавиши\n" +
                " - Ctrl + 1 - Алгоритмы\n" +
                " - Ctrl + 2 - Опыты\n" +
                " - Ctrl + 3 - Экзамен\n" +
                " - Ctrl + 4 - Дневник\n" +
                " - Ctrl + 5 - Калькулятор\n" +
                " - esc - меню\n" +
                "(чтобы они работали главное\nокно должно быть активным)\n\n" +
                "Локальные горячие клавиши:\n" +
                "в Алгоритмах:\n - Enter - изменить алгоритм\n" +
                "в Опытах:\n - Enter - преобразовать входные данные\n" +
                "в Экзамене:\n - Enter - перейти на следующий тест\n" +
                "в Калькуляторе:\n - Enter - произвести расчёт\n" +
                "(чтобы они работали нужно\nнаходиться в поле ввода)\n\n" +
                "Уточнения по работе:\n" +
                " - все деления происходят нацело\n(отбрасывается десятичная часть)\nили деление не разрешается\n" +
                " - все алгоритмы игнорируют английские буквы\nили запрещают их наличие во входных данных\n" +
                " - текст в квадратных скобках - это пояснения\nот разработчиков\n" +
                "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.information_is_open = false;
        }
    }
}
