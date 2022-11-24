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
                " - Shift + 1 - Алгоритмы\n" +
                " - Shift + 2 - Опыты\n" +
                " - Shift + 3 - Экзамен\n" +
                " - Shift + 4 - Дневник\n" +
                " - Shift + 5 - Калькулятор\n" +
                " - esc - меню\n" +
                "(чтобы они работали главное\nокно должно быть активным)\n\n" +
                "Локальные горячик клавиши:\n" +
                "в Алгоритмах:\n - enter - изменить алгоритм\n" +
                "в Опытах:\n - enter - преобразовать входные данные\n" +
                "в Экзамене:\n - enter - переёти на следующий тест\n" +
                "в Калькуляторе:\n - enter - произвести рассчёт\n" +
                "(чтобы они работали нужно\nнаходиться в поле ввода)\n\n" +
                "Уточнения по работе:\n" +
                " - все деления происходят нацело\nили деление не разрешается\n" +
                "(отбрасывается десятичная часть)\n\n";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.information_is_open = false;
        }
    }
}
