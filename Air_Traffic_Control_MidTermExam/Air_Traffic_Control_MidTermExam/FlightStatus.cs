using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Control_MidTermExam
{
    enum FlightStatus
    {
        Parked = 1, 

        TaxiingFromGate = 2,

        WaitingToTakeOff = 3,

        TakingOff = 4,

        Climbing = 5,

        ApproachingRunway = 6,

        Landing = 7,

        TaxxingToGate = 8,

        AtGate = 9,

        ChangingAltitude = 10,
    }
}
