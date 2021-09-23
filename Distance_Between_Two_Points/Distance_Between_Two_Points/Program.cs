using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Lab Exercises-3 
Exercise 12
  */

namespace Distance_Between_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter X1 and Y1 coordinates ");
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter X2 and Y2 coordinates ");
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine("The distance between two coordinates is: {0}",  Distance(x1, y1, x2, y2) );

            Console.ReadLine();
        }
        static double Distance(double x1, double x2, double y1, double y2)
        {
        
         return (Math.Sqrt((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

         
        }
    }
}
