using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly IEvGrantRepository _evGrantRepository;
        public AddressesController(IEvGrantRepository evGrantRepository){
            _evGrantRepository = evGrantRepository ??
             throw new ArgumentNullException(nameof(evGrantRepository));
        }

        [HttpGet("{postcode}")] 
        public async Task<ActionResult<AddressDto>> GetAddresses(string postcode)
        {
            var addressToReturn = await _evGrantRepository.GetAddresses(postcode);

            if (addressToReturn == null){
                return NotFound();
            }
            return Ok(addressToReturn);
        }

        [HttpGet("Check/{postcode}")] 
        public async Task<ActionResult<Boolean>> CheckAddress(string postcode)
        {
            var eligibility = await _evGrantRepository.CheckAddress(postcode);

            if (eligibility == null){
                return false;
            }
            return true;
        }
    }
}