using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/Vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IEvGrantRepository _evGrantRepository;
        public VehiclesController(IEvGrantRepository evGrantRepository){
            _evGrantRepository = evGrantRepository ??
             throw new ArgumentNullException(nameof(evGrantRepository));
        }
        
        [HttpGet("{vrn}")] 
        public async Task<ActionResult<VehicleDto>> GetVehicles(string vrn)
        {
            var addressToReturn = await _evGrantRepository.GetVehicle(vrn);

            if (addressToReturn == null){
                return NotFound();
            }
            return Ok(addressToReturn);
        }
        [HttpGet("/check/{fuel_type}")] 
        public async Task<ActionResult<Boolean>> CheckVehicle(string fuel_type)
        {
            var eligibility = await _evGrantRepository.CheckVehicle(fuel_type.ToLower());

            if (eligibility == null){
                return false;
            }
            return true;
        }
    }
}