using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagram
{
    class BritishSystem : Gradebook
    {
        public BritishSystem(string courseName, int[] grades) : base(courseName, grades)
        {
            GetCredits = Convert.ToDecimal(3.5);     //British credit is 3.5 hours.
        }

       
        public override int GetNumberOfHours()
        {
            return decimal.ToInt32(GetCredits) * FinalGrades.Length;   
        }

      //  for the British coursebook, the passing grades are those greater than or equal to 50,
        public override int GetNumberOfPasses()
        {
            int count = 0;
            for (int i = 0; i < FinalGrades.Length; i++)
            {
                if (FinalGrades[i] >= 50)
                {
                    count++;
                }
            }
            return count;
        }

        //in the British courses, those grades that are 70 or more, are considered as Distinctions.
       //Thus, the method GetNumberOfDistinctions() in class BritishGradebook returns the number of grades >= 70.

        //So, this method get distictions count
        public int GetNumberOfDistinctions()
        {
            int count = 0;
            for (int i = 0; i < FinalGrades.Length; i++)
            {
                if (FinalGrades[i] >= 70)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
