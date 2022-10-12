using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Lab_2
{
    internal class Point  // модификатор internal делает, так что класса доступен из любого места кода в той же сборке
    {                    // класс описывает точки в двухмерном пространстве
        private double x;  // координата точки по оси Абцисс
        private double y;  // координата точки по оси Ординат
        private char name;  // название точки, нужно для того чтобы их различать

        public Point(double x, double y, char name)  // конструктор копирования
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public Point()  // конструктор, заполняющий поля случайным образом
        {
            Random random = new Random();
            this.x = random.Next(-10, 10) + Math.Round(random.NextDouble(), 1);
            this.y = random.Next(-10, 10) + Math.Round(random.NextDouble(), 1);
            this.name = (char)random.Next(65, 90);
        }
        
        public char Name
        {
            get { return name; }
        }

        public void Get_info()  // метод, выводящий все поля объекта в консоль
        {
            Console.WriteLine($"Точка {this.name}:\n{this.x}\n{this.y}\n");
        }

        override public string ToString()  // переопределяем существующий метод ToString, при помощи модификатора override
        {                                 //метод возвращающий стороку, в которой содержатся все поля класса
            return (this.x + "  " + this.y + "  " + this.name);
        }

        public double Remoteness()  // расстояние от точки до центра координат
        {                          // Remoteness - удалённость
            return Math.Round(Math.Sqrt(this.x * this.x + this.y * this.y), 3);
        }

        public static Point operator --(Point point1)  // перегрузка унарного оператора для нашего класса
                                                      // применив на объект операцию -- из полей координат вычтется по единице
        {
            point1.x--;
            point1.y--;
            return point1;
        }

        public static Point operator -(Point point1)  // перегрузка унарного оператора -
        {                                            // поля координат объкта меняются местами
            double x_save = point1.x;
            point1.x = point1.y;
            point1.y = x_save;
            return point1;
        }

        public static implicit operator int(Point point1)  // Перегрузка операций преобразования типов. Модификатор implicit отвечает за неявное преобразование типов
        {                                                  // Если объект присваивается перменной типа int, то берётся поле X и присваивается перемнной int
            return (int)point1.x;  // явное преобразование типов, так как изначально поля типа double
        }

        public static explicit operator double(Point point1)  // Перегрузка операций преобразования типов. Модификатор explicit отвечает за явное преобразование типов ( когда перед переменной в скобках указазываем новый тип )
        {                                                     // Если объект присваивается перменной типа double, то берётся поле Y и присваивается перемнной double
            return point1.y;
        }

        public static Point operator -(Point point1, int number)  // перегрузка бинарног оператора вычитания.
        {                                                        // когда из точки вычитается целое число, то уменьшается Х координата на это число
            point1.x -= number;
            return point1;
        }

        public static Point operator -(int number, Point point1)  // перегрузка бинарног оператора вычитания.
        {                                                        // когда из целого числа вычитается точка, то уменьшается Y координата на это число         
            point1.y -= number;
            return point1;
        }

        public static double operator -(Point first, Point second)  // перегрузка бинарног оператора вычитания. 
        {                                                          // при вычитании одного объекта из другого, то есть одной точки из другой, между ними считается расстояние   
            Console.Write($"Расстояние между точками {first.Name} и {second.Name}: ");
            double result = Math.Pow(first.x - second.x, 2) + Math.Pow(first.y - second.y, 2);
            return Math.Round(Math.Sqrt(result), 3);
        }
    }
}
