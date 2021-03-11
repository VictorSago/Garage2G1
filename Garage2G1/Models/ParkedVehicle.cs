using Garage2G1.Models.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2G1.Models
{
    public class ParkedVehicle
    {

        public int Id { get; set; }

        [RequiredEnumAttribute]
        public VehicleType VehicleType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(6)]
        public string RegNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Color { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Model { get; set; }

        [Range(0, int.MaxValue)]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Total Time Parked")]
        public TimeSpan ParkedTime { 
            get 
            {
                return DateTime.Now - ArrivalTime;
            }
        }

    }
    
    
}
