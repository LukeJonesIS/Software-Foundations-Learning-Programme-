using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;
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
    }
}