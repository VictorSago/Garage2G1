using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2G1.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public VehicleType VehicleType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
    
    public enum VehicleType
    {
        Car,
        Bus,
        Boat,
        Motorcycle,
        Plane
    }
}
