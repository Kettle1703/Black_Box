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
            inform.Text = "Полезная информация:\n\nОбщие горячие клавиши\n - Shift + 1 - Алгоритмы\n - Shift + 2 - Опыты\n - Shift + 3 - Экзамен\n - Shift + 4 - Дневник\n - Shift + 5 - Калькулятор\n - esc - меню\n(чтобы они работали главное\nокно должно быть активным)\n\nЛокальные сочетания клавиш:\nв Алгоритмах:\n - enter - изменить алгоритм\nв Опытах:\n - enter - преобразовать входные данные\nв Экзамене:\n - enter - переёти на следующий тест\nв Калькуляторе:\n - enter - произвести рассчёт\n(для того чтобы они работали\nнужно находиться в поле ввода)\n1\n1\n1\n1\n1\n1\n1\n";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.information_is_open = false;
        }
    }
}
