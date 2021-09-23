using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Control_MidTermExam
{
    class Program
    {
        static void Main(string[] args)
        {
            AirTrafficControl Air = new AirTrafficControl();           

              int new_altitude = 25000;

            Console.WriteLine("\n\t--------------------WELCOME!!--------------------\n");                                       
            Console.WriteLine("---------------Air Traffic Control (ATC) Simulator---------------\n");            

            Air.Initialize();
            Air.Get_All_Flight_Information();
                                   
            Console.WriteLine("\n " + Air.Fisrt_Flight.Airplane.Carrier +" "+ Air.Fisrt_Flight.FlightNumber + " is climbing to an altitude of "+Air.Fisrt_Flight.Altitude + " to "+ new_altitude + "\n");
             Air.Fisrt_Flight.SetAltitude(new_altitude);

            Console.WriteLine("\n " + Air.Fisrt_Flight.Airplane.Carrier + " "+ Air.Fisrt_Flight.FlightNumber + " is changing status to CLIMBING." + "\n");
            Air.Fisrt_Flight.ChangeFlightStatus(5);

            Console.WriteLine("");

            Air.Fisrt_Flight.ChangeFlightStatus(9);

            Air.Fisrt_Flight.changeAltitude(12000);
            Console.WriteLine("________________________________________________________________________________");

            Console.Read();
        }          
    }
}
