using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2G1.Models
{
    public class ParkedVehicle
    {

        public ParkedVehicle()
        {
            ArrivalTime = DateTime.Now;
        }

        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; private set; }

    }
    
    
}
