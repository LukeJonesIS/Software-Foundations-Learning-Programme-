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
                    Vrn = "EVS400",
                    Make = "Tesla",
                    Model = "Series S",
                    Year_made = 2018,
                    Fuel_type = "electric"
                },

                new VehicleDto()
                {
                    Vrn = "CAS300",
                    Make = "Volkswagon",
                    Model = "Fox",
                    Year_made = 2008,
                    Fuel_type = "petrol"
                }
            };
        }
    }
}