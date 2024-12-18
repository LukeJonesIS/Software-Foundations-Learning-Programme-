using Microsoft.AspNetCore.SignalR;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.DataStore
{
    public class VehiclesDataStore
    {
        public List<VehicleDto> Vehicles {get; set;}
        public static VehiclesDataStore Current { get;} = new VehiclesDataStore();

        public VehiclesDataStore()
        {
            Vehicles = new List<VehicleDto>()
            {
                new VehicleDto()
                {
                    vrn = "EVS400",
                    make = "Tesla",
                    model = "Series S",
                    year_made = 2018,
                    fuel_type = "electric"
                },

                new VehicleDto()
                {
                    vrn = "CAS300",
                    make = "Volkswagon",
                    model = "Fox",
                    year_made = 2008,
                    fuel_type = "petrol"
                }
            };
        }
    }
}