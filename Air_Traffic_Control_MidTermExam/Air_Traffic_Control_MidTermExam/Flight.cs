using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Control_MidTermExam
{
    class Flight
    {

        public FlightStatus Status { get; set; }
        public Airplane Airplane { get; set; }
        public int Altitude { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string FlightNumber { get; set; }

        public Flight(FlightStatus status, Airplane airplane, string destination, string departureTime, string arrivalTime, string direction, int altitude, int speed, string origin, string flightnum)
        {
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Direction = direction;
            Altitude = altitude;
            Speed = speed;
            Origin = origin;
            FlightNumber = flightnum;
            Status = status;
            Airplane = airplane;

        }
        public void ChangeFlightStatus(int status_data)
        {
            switch (status_data)
            {
                case 1:
                    Status = FlightStatus.Parked;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " Flight Status updated to PARKED");
                    break;
                case 2:
                    Status = FlightStatus.TaxiingFromGate;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " Flight Status updated to TAXXING FROM GATE");
                    break;          
                case 3:
                    Status = FlightStatus.WaitingToTakeOff;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to WAITING TO TAKE OFF");
                    break;
                case 4:
                    Status = FlightStatus.TakingOff;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to TAKING OFF");
                    break;
                case 5:
                    Status = FlightStatus.Climbing;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to CLIMBING");
                    break;
                case 6:
                    Status = FlightStatus.ApproachingRunway;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to APPROACHING RUNWAY");
                    break;
                case 7:
                    Status = FlightStatus.Landing;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to LANDING");
                    break;
                case 8:
                    Status = FlightStatus.TaxxingToGate;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " updated to TAXIING TO GATE");
                    break;
                case 9:
                    Status = FlightStatus.ChangingAltitude;
                    Console.WriteLine(">> [" + Airplane.Carrier + "]" + " Flight Status for " + "[" + FlightNumber + "]" + " is to be descend to 12000  feet ");
                    break;
                default:
                    return;
            }
        }

        public void SetAltitude(int altitude)
        {

            Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " is changing the altitude!!\n ");

            int Altitude1 = Altitude;

            FlightStatus temp = Status;

            Status = FlightStatus.ChangingAltitude;
            Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " Status updated!\n");

            Altitude = altitude;

            Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " The flight altitute increased to " + Altitude + "\n");

            Status = temp;

            Console.WriteLine(">> [" + Airplane.Carrier + "]" + " " + "[" + FlightNumber + "]" + " The status restored after changing altitude.\n");

            Console.WriteLine(" [RADIO] " + Airplane.Carrier + " " + FlightNumber + " " + " is changing the altitude from " + Altitude1 + " to " + altitude + ".");
        }

        public void changeAltitude(int altitude){

            Altitude = altitude;
            Console.WriteLine("\n " + Airplane.Carrier + " " + FlightNumber + " has descend to "+ altitude + " feet " + "\n");
            
        }

        public void Print_Flight_Information()
        {
            Console.WriteLine("\t\t Information About The Airplane  ");
       
            Console.WriteLine("________________________________________________________________________________");

            Airplane.Display_Airplane_Information();                                        

            Console.WriteLine("DESTINATION\t-\t" + Destination + "\n"+ "\nDEPARTURE TIME \t-\t" + DepartureTime + "\n" + "\nARRIVAL TIME\t-\t" + ArrivalTime + "\n" );
            Console.WriteLine("DIRECTION\t-\t" + Direction + "\n" + "\nALTITUDE\t-\t" + Altitude + "\n" + "\nSPEED\t\t-\t" + Speed + "\n" + "\nORIGIN\t\t-\t" + Origin + "\n"+ "\nFLIGHT NUMBER\t-\t" + FlightNumber);

            Console.WriteLine("________________________________________________________________________________"); 
        }
    }
}

