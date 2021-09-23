using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     Assignment 1 
     Exercise 2
     */

namespace UML_Diagram
{
    class Program
    {
        //After implementing the inheritance hierarchy, write another class with a Main() method,
        //creating an array of courseNames of all three different types.

        static void Main(string[] args)
        {
         //Create an array of courses of all three different types. Initialize those courses to sample course names and grade values.

            Gradebook[] courseNames = new Gradebook[3];
            int[] gradeValues = { 88, 50, 65 };

            //Then, iterate polymorphically through every course and print its name, number of credits, number of hours,
            //average grade, and number of passes.

            // Here I added value for all systems
            courseNames[0] = new USsystem("US CourseBook", gradeValues);

            courseNames[1] = new BritishSystem("British CourseBook", gradeValues);

            courseNames[2] = new AlbanianSystem("Albanian CourseBook", gradeValues);

            // This condition will display details for all three systems
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Name: " + courseNames[i].GetCourseName +"\n");

                Console.WriteLine("Number of credit: " + courseNames[i].GetCredits + "\n");

                Console.WriteLine("Number of hours: " + courseNames[i].GetNumberOfHours() + "\n");

                Console.WriteLine("Average grade: " + courseNames[i].GetCourseAverage() + "\n");

                Console.WriteLine("Number of passes: " + courseNames[i].GetNumberOfPasses() + "\n");

                                                                                            
                // For those courses that are British, in the repetition loop also print the number of distinctions.

                if (courseNames[i].GetType().Name == "BritishSystem")
                {
                    BritishSystem british = (BritishSystem)(courseNames[i]);

                    Console.WriteLine("Number of distinctions: " + british.GetNumberOfDistinctions() + "\n");
                }

                Console.WriteLine("-----------------------------------------------------------------");
            }
            Console.Read();
        }
    }
}
