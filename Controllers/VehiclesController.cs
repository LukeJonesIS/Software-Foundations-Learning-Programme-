using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/Vehicles")]
    public class VehiclesController : ControllerBase
    {
        [HttpGet("{vrn}")] 
        public ActionResult<VehicleDto> GetVehicles(string vrn)
        {
            var VehicleToReturn = VehiclesDataStore.Current.Vehicles
                .FirstOrDefault(a => a.Vrn == vrn);

            if (VehicleToReturn == null){
                return NotFound();
            }
            return Ok(VehicleToReturn);
        }
    }
}