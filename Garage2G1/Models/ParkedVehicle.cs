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

        [Display(Name = "Vehicle Type")]
        [RequiredEnumAttribute]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Registration Number")]
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

        [Display(Name = "No of Wheels")]
        [Range(0, int.MaxValue)]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd, hh:mm}", ApplyFormatInEditMode = true)]
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
