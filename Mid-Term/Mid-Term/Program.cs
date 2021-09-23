using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   /*
14. Write an application that uses a foreach statement to calculate and print 
the average of the double values passed by the command-line arguments.(15%)               
    */

namespace Mid_Term
{
    class Program
    {
        static void Main(string[] args)
        {
            var integer1 = 8.3;
            var integer2 = 2.4;

            Console.WriteLine($"num1 = {integer1:F1}\nnum2 = {integer2:F1}");
            Console.WriteLine($"The average of double numbers is: {calculate(integer1, integer2):F1}");

            Console.ReadKey();
        }
        static double calculate(params double[] numbers)
        {
            double average;      

            var Result = 0.0;

            foreach (var integer in numbers)
            {
                Result += integer;
            }
             
            return average = Result / numbers.Length; ;

        }
    }
}
