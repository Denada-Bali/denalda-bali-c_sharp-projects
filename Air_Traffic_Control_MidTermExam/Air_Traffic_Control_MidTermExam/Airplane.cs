using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Control_MidTermExam
{
    class Airplane
    {
        public Airplane(){}

            public string Make { get; set; }
            public string Model { get; set; }
            public string Carrier { get; set; }

            public Airplane(string make, string model, string carrier)
            {
                Make = make;
                Model = model;
                Carrier = carrier;
            }

                           
        public void Display_Airplane_Information()
            {
                Console.WriteLine("\nMAKE\t\t-\t" + Make + "\n" + "\nMODEL\t\t-\t" + Model + "\n" + "\nCARRIER\t\t-\t" + Carrier+ "\n");
               
            }
    }
}
