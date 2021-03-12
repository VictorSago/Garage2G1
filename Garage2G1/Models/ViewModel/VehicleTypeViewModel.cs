using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2G1.Models.ViewModel
{
    public class VehicleTypeViewModel
    {
        public List<ParkedVehicle> Vehicles { get; set;}
        public SelectList Types { get; set; }
        public string ParkedVehicleType { get; set; }
        public string SearchString { get; set; }
        
    }
}