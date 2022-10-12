using System;

namespace C_Lab_2
{
    class Program
    {
        static void Main()
        {
            Point point_1 = new Point();
            Point point_2 = new Point(10, 1.4, 'F');
            Point point_3 = new Point(-1, -1, 'E');
            point_1.Get_info();
            point_2.Get_info();
            int number = point_1;
            //char number_3 = point_1;
            double number_2 = (double)point_1;
            Console.WriteLine($" int {number} double {number_2}");
            Console.WriteLine($"Получение полей объектов строками:\n{point_1.ToString()}   {point_2.ToString()}\n");
            Console.WriteLine($"Удалённость точки {point_1.Name} {point_1.Remoteness()}\n");
            /*
            point_1 = point_1 - 10;
            point_1.Get_info();
            point_1 = 10 - point_1;
            point_1.Get_info();
            */
            //point_2--;
            //Console.WriteLine(-point_2);
            //point_2.Get_info();
            
            //Console.WriteLine(point_2 - point_3);
            //Операции приведения типа: в переменную целого типа записывается x
            //                          в переменную вещественного типа записывается y
            /*
            Бинарные операции:
            – Point p, целое число(левосторонняя операция,
            уменьшается координата х);  
            
            point2 - 13 и 13 вычитается из поля х
            
            
            – целое число, Point p(правосторонняя операция,
            уменьшается координата y);  
            
            13 - point2 и 13 вычитается из поля у
            
           
            – Point p – вычисляется расстояние до точки p, результатом
            должно быть вещественное число.  
            
            point1 + point2  расстояние между точками (оператор можно поменять)
            */
        }
    }
}