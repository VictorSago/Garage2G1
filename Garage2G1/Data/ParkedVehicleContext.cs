using Garage2G1.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage2G1.Data
{
    public class ParkedVehicleContext : DbContext
    {

        public ParkedVehicleContext(DbContextOptions<ParkedVehicleContext> options) : base(options)
        {
        }

        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }

    }
}
