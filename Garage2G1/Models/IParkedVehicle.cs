using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2G1.Models
{
    public interface IParkedVehicle
    {
        public IEnumerable<ParkedVehicle> Vehicles { get; }

        public ParkedVehicle GetParkedVehicleById(int Id) 
        {
            return this.Vehicles.FirstOrDefault(v => v.Id == Id);
        }

    }
}
