using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Lab Exercises-3 
 Exercise 4
     */

namespace Parking_Garage_Charge
{
    class Program
    {
        static void Main(string[] args)
        {
            double grandTotal = 0;
            double car1 = 0, car2 = 0, car3 = 0;
            double car1c = 0, car2c = 0, car3c = 0;

            Console.WriteLine ( "Please input the amount of hours car 1 was parked: ");
            car1 = double.Parse(Console.ReadLine());

            car1c = calculateCharges(car1);
            Console.WriteLine("\nCharge for car1 is: {0:C}", car1c );

            Console.WriteLine("\nPlease input the amount of hours car 2 was parked.");
            car2 = double.Parse(Console.ReadLine());
            
            car2c = calculateCharges(car2);
            Console.WriteLine("\nCharge for car2 is: {0:C}", car2c );

            Console.WriteLine("\nPlease input the amount of hours car 3 was parked.");
            car3 = double.Parse(Console.ReadLine());

            car3c = calculateCharges(car3);
            Console.WriteLine("\nCharge for car3 is: {0:C}", car3c);

            grandTotal = car1c + car2c + car3c;

            Console.WriteLine("\n\nGrand total for the day is: {0:C} ", grandTotal);

            Console.ReadLine();
        }

        static double calculateCharges(double hours)
        {
            if (hours < 3)
                return 2.00;
            else
            {
                if (hours < 24)
                    return 2.00 + (hours - 3) * 0.5;
                else
                    return 10.00;

            }
        }
    }
}
