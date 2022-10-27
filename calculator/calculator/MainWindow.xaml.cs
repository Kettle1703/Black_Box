﻿using System;
using System.Data;
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

namespace calculator
{
    
    public partial class MainWindow : Window
    {
        private bool have_syntactic_mistake = false;  // поле хранящее информацию о начилии синтактической ошибки 
        private static int Quantity_search(string str, char letter)  // метод, считающий количество вхождений переданного символа в строку
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == letter)
                    result++;
            return result;
        }
        private static bool Сorrect_brackets(string str)  // метод распознающий неправильную скобочную последовательность
        {
            int open = MainWindow.Quantity_search(str, '(');
            int close = MainWindow.Quantity_search(str, ')');
            if (open == close)
            {
                string input = "";
                for (int i = 0; i < str.Length; i++)
                    if (str[i] == '(' || str[i] == ')')
                        input += str[i];
                bool flag = true;
                while (flag && input.Length != 0)
                {
                    if (input[0] == ')' || input[input.Length - 1] == '(')
                        flag = false;
                    for (int i = 0; i < (input.Length - 1); i++)
                        if (input[i] == '(' && input[i + 1] == ')')
                            input = input.Remove(i, 2);
                }
                if (input.Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // метод обрабазывающий нажатие кнопок 
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                textbox.Text = "";

            if (str == "C") {
                int len = textbox.Text.Length;
                textbox.Text = textbox.Text.Remove(len - 1, 1);
            }

            if (str == "=")
            {
                    
                if (MainWindow.Сorrect_brackets(textbox.Text))
                {
                    string value = new DataTable().Compute(textbox.Text, null).ToString();
                    textbox.Text = value;
                }
                else
                {
                    textbox.Text = "Синтактическая ошибка";
                    have_syntactic_mistake = true;
                }
            }
            
            if (str != "AC" && str != "C" && str != "=")
                if(have_syntactic_mistake)
                {
                    have_syntactic_mistake = false;
                    textbox.Text = "";
                    textbox.Text += str;
                }
                else
                    textbox.Text += str;


            
            

        }

        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement elem in Buttonlist.Children)  
            {
                if (elem is Button)  
                    ((Button)elem).Click += Button_Click;
                
            }
        }
    }
}
