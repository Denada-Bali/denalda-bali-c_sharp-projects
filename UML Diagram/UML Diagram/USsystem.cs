using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagram
{
    class USsystem : Gradebook
    {
        public USsystem(string courseName, int[] grades) : base(courseName,grades)
        {
            GetCredits = 15;             // American credit is 15 hours,
        }

        //Abstract methods are implemented 
        public override int GetNumberOfHours()
        {
            return decimal.ToInt32(GetCredits) * FinalGrades.Length;
        }

        //For the American coursebook, the passing grades are those greater than or equal to 70,
        public override int GetNumberOfPasses()
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