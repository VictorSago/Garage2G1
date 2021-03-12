using System;
using System.Linq;
using Garage2G1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Garage2G1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ParkedVehicleContext(
                serviceProvider.GetRequiredService<DbContextOptions<ParkedVehicleContext>>()))
            {
                // Look for vehicles
                if (context.ParkedVehicle.Any())
                {
                    return;     // DB has been seeded
                }

                context.ParkedVehicle.AddRange(
                    new ParkedVehicle
                    {
                        RegNumber = "123ABC",
                        VehicleType = VehicleType.Car,
                        Brand = "Volvo",
                        Model = "600SL",
                        Color = "Blue",
                        NumberOfWheels = 4,
                        // So that we have a variety of times in the DB
                        ArrivalTime = DateTime.Parse("2021-03-10 10:00")
                        // ArrivalTime = DateTime.Now//.ToString("yyyy/MM/dd HH:mm:ss")
                    },
                    new ParkedVehicle
                    {
                        RegNumber = "123DEF",
                        VehicleType = VehicleType.Car,
                        Brand = "Ferrari",
                        Model = "Testarosa",
                        Color = "Red",
                        NumberOfWheels = 4,
                        ArrivalTime = DateTime.Parse("2021-03-10 22:00")
                        // ArrivalTime = DateTime.Now//.ToString("yyyy/MM/dd HH:mm:ss")
                    },
                    new ParkedVehicle
                    {
                        RegNumber = "666GGG",
                        VehicleType = VehicleType.Motorcycle,
                        Brand = "Yamaha",
                        Model = "300K",
                        Color = "Yellow",
                        NumberOfWheels = 2,
                        ArrivalTime = DateTime.Parse("2021-03-12 1:30")
                        // ArrivalTime = DateTime.Now//.ToString("yyyy/MM/dd HH:mm:ss")
                    },
                    new ParkedVehicle
                    {
                        RegNumber = "999KLM",
                        VehicleType = VehicleType.Bus,
                        Brand = "Volvo",
                        Model = "XVB111",
                        Color = "White",
                        NumberOfWheels = 8,
                        ArrivalTime = DateTime.Parse("2021-03-11 13:30")
                        // ArrivalTime = DateTime.Now//.ToString("yyyy/MM/dd HH:mm:ss")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
