using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, 5)]
        public VehicleType VehicleType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string RegNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Color { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        [Range(1, int.MaxValue)]
        public int NumberOfWheels { get; set; }
        [Display(Name = "Order Date")]
        public DateTime ArrivalTime { get; private set; }

    }
    
    
}
