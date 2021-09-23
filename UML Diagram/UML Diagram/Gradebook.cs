using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagram
{
    abstract class Gradebook
    {

        public string courseName;
        public decimal NumberOfCredits;
        protected int[] FinalGrades;

        // The base class constructor is overloaded in two versions: one taking only the course name as
        // parameter, the other taking both the course name and an array of integer grades.

        // here is the constructor 1  which take only the course name.

        public Gradebook(string courseName)
        {
            this.courseName = courseName;
            NumberOfCredits = 0;
        }

        // here is the constructor 2  which take both the course name and an array of integer grades.
        public Gradebook(string courseName, int[] grades)
        {
            this.courseName = courseName;
            NumberOfCredits = 0;
            this.FinalGrades = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                this.FinalGrades[i] = grades[i];
            }
        }

        //Method GetCourseAverage() calculates the average of all grades and returns a double value.
        //If there are no grades available, it should return -1.
        public double GetCourseAverage()
        {
            double average = 0;
            if (FinalGrades.Length == 0)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < FinalGrades.Length; i++)
                {
                    double val = decimal.ToDouble(NumberOfCredits);
                    val *= FinalGrades[i];
                    average += val;
                }
                return average / (Convert.ToDouble(NumberOfCredits) * FinalGrades.Length);
            }
        }

        public string GetCourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }

    //Property “Credits” should check in the setter that the number is non-negative, else it throws an ArgumentOutOfRangeException.
        public decimal GetCredits
        {
            get
            {
                return NumberOfCredits;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Credits shouldn't be negative!!!");
                }
                else
                {
                    NumberOfCredits = value;
                }
            }
        }

       //Methods GetNumberOfPasses() and GetNumberOfHours() are designed to be called polymorphically and defined as abstract.
        public abstract int GetNumberOfPasses();

        public abstract int GetNumberOfHours();
    }
}
