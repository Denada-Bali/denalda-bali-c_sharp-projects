using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;                                                                             

namespace Air_Traffic_Control_MidTermExam
{
    class AirTrafficControl
    {
        public  Flight Fisrt_Flight;
        public  Flight Second_Flight;
        public  Flight Third_Flight;

        public void Get_All_Flight_Information()
        {
            Fisrt_Flight.Print_Flight_Information();
            Console.WriteLine();

            Second_Flight.Print_Flight_Information();
            Console.WriteLine();

            Third_Flight.Print_Flight_Information();
            Console.WriteLine();
        }

        public void Initialize()                               
        {
            Fisrt_Flight = new Flight(FlightStatus.ApproachingRunway, new Airplane("The Canadair Regional Jet", "CRJ900", "Alaska Airlines"), "ALB", "07:30", "20:30", "South",  12500, 880, "JFK", "AS1");

            Second_Flight = new Flight(FlightStatus.TakingOff, new Airplane("The Douglas", "DC-3", "JetBlue Airways"), "MSY", "18:35", "17:35", "South", 1600, 333, "MIA", "B61");

            Third_Flight = new Flight(FlightStatus.Climbing, new Airplane("Boeing", "737", "Spirit Airlines"), "BOS", "20:00","21:07", "East", 41000, 583, "JFK", "NK1");
        }
    }
}
