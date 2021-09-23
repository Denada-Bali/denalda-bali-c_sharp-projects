using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagram
{
    class AlbanianSystem : Gradebook
    {   

        public AlbanianSystem(string courseName, int[] grades) : base(courseName, grades)
        {
            GetCredits = Convert.ToDecimal(7.5);       //Albanian credit is 7.5 hours,
        }
                                           
        public override int GetNumberOfHours()
        {
            return decimal.ToInt32(GetCredits) * FinalGrades.Length;
        }

      //  Albanian coursebook, the passing grades are those greater than or equal to 45.
        public override int GetNumberOfPasses()
        {
            int count = 0;
            for (int i = 0; i < FinalGrades.Length; i++)
            {
                if (FinalGrades[i] >= 45)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
